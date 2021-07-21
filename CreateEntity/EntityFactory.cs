using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CreateEntity
{
    public class EntityFactory
    {
        private readonly IDB db;

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
        }

        public void Create(BackgroundWorker worker, DoWorkEventArgs e)
        {
            using (DbConnection conn = Helper.GetDbConnection())
            {
                conn.Open();
                List<Table> tables = db.GetTableAll(conn);

                for (int i = 0; i < tables.Count(); i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    List<TableColumn> tableColumn = db.GetTableColumn(conn, tables[i]);
                    CodeGenerator.BuildEntityClass(tables[i], tableColumn);
                    //汇报进度
                    worker.ReportProgress((int)((double)(i + 1) / tables.Count * 100));
                }

            }
        }
    }
}
