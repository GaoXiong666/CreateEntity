using CreateEntity.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CreateEntity
{
    public class EntityFactory
    {
        private readonly IDB db;
        private readonly CancellationTokenSource _cts;
        private List<string> filesName;

        public EntityFactory(DataBaseType type)
        {
            switch (type)
            {
                case DataBaseType.Oracle:
                    db = new Oracle();
                    break;
                case DataBaseType.SqlServer:
                    db = new SqlServer();
                    break;
                default:
                    throw new Exception("此数据库功能暂未实现");
            }
            _cts = new CancellationTokenSource();
            Init();
        }

        public void Create(ProgressBar pgb)
        {
            var token = _cts.Token;
            using (DbConnection conn = Helper.GetDbConnection())
            {
                conn.Open();
                List<Table> tables = db.GetTableAll(conn).OrderBy(i => i.CSharpName).ToList();

                pgb.Maximum = tables.Count();
                for (int i = 0; i < tables.Count(); i++)
                {
                    token.ThrowIfCancellationRequested();//申请取消

                    if (Helper.IsReplace||
                        filesName.FindIndex(f => f==(tables[i].CSharpName + ".cs").ToLower()) == -1)
                    {
                        List<TableColumn> tableColumn = db.GetTableColumn(conn, tables[i])
                                                          .OrderBy(o => o.ConstraintType)
                                                          .ThenBy(o => o.CSharpName)
                                                          .ToList();
                        CodeGenerator.BuildEntityClass(tables[i], tableColumn);
                    }

                    //汇报进度
                    pgb.Value = i + 1;
                }
                //生成上下文
                if (Helper.IsDbContext)
                {
                    CodeGenerator.BuildEFCoreDbContext(tables);
                }
            }
        }

        public void Cancel()
        {
            if (_cts != null)
                _cts.Cancel();
        }

        public void Init()
        {
            filesName = new List<string>();
            if (!Helper.IsReplace)
            {
                DirectoryInfo infos = new DirectoryInfo(Helper.path);
                FileInfo[] files = infos.GetFiles();
                foreach(var file in files)
                {
                    filesName.Add(file.Name.ToLower());
                }
            }
        }
    }
}
