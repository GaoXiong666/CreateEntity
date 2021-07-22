using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

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
            else
            {
                throw new Exception("此数据库功能暂未实现");
            }
            _cts = new CancellationTokenSource();
        }

        public void Create(ProgressForm form)
        {
            var token = _cts.Token;
            using (DbConnection conn = Helper.GetDbConnection())
            {
                conn.Open();
                List<Table> tables = db.GetTableAll(conn);

                for (int i = 0; i < tables.Count(); i++)
                {
                    token.ThrowIfCancellationRequested();//结束请求

                    List<TableColumn> tableColumn = db.GetTableColumn(conn, tables[i]);
                    CodeGenerator.BuildEntityClass(tables[i], tableColumn);
                    
                    //汇报进度
                    form.progressBar1.Value= (int)((double)(i + 1) / tables.Count * 100);
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
