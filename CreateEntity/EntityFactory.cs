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
        private  CancellationTokenSource _cts;

        public EntityFactory(DataBaseType type)
        {
            if (type == DataBaseType.Oracle)
            {
                db = new Oracle();
            }
            else if (type == DataBaseType.SqlServer)
            {
                db = new SqlServer();
            }
            else
            {
                throw new Exception("此数据库功能暂未实现");
            }
            _cts = new CancellationTokenSource();
        }

        public void Create(ProgressBar pgb)
        {
            var token = _cts.Token;
            using (DbConnection conn = Helper.GetDbConnection())
            {
                conn.Open();
                List<Table> tables = db.GetTableAll(conn);

                pgb.Maximum = tables.Count();
                for (int i = 0; i < tables.Count(); i++)
                {
                    token.ThrowIfCancellationRequested();//申请取消

                    List<TableColumn> tableColumn = db.GetTableColumn(conn, tables[i]);
                    CodeGenerator.BuildEntityClass(tables[i], tableColumn);

                    //汇报进度
                    pgb.Value = i + 1;
                }
            }
        }

        public void Cancel()
        {
            if (_cts != null)
                _cts.Cancel();
        }
    }
}
