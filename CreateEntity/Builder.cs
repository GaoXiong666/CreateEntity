using Oracle.ManagedDataAccess.Client;
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
    public interface IDB
    {
        List<Table> GetTableAll(DbConnection conn);

        List<TableColumn> GetTableColumn(DbConnection conn, Table table);
    }

    public class Builder
    {
        private readonly IDB db;

        public Builder(DataBaseType type)
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
                    BuildClass(tables[i], tableColumn);

                    worker.ReportProgress((int)((double)(i + 1) / tables.Count * 100));
                }

            }
        }

        /// <summary>
        /// 生成cs文件
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        private void BuildClass(Table table, List<TableColumn> columns)
        {
            columns.ForEach(x =>
            {
                string csharpType = DataTypeMapping.dbColumnDataTypes.FirstOrDefault(t =>
                        t.DatabaseType == Helper.dbType && t.ColumnTypes.Split(',').Any(p =>
                            p.Trim().Equals(x.DataType, StringComparison.OrdinalIgnoreCase)))?.CSharpType;
                if (string.IsNullOrEmpty(csharpType))
                {
                    throw new Exception($"未从字典中找到\"{x.DataType}\"对应的C#数据类型");
                }

                x.CSharpType = csharpType;
            });

            //生成属性
            StringBuilder sb = new StringBuilder();
            foreach (TableColumn column in columns)
            {
                string tmp = CodeGenerator.GenerateEntityProperty(column);
                sb.AppendLine(tmp);
            }

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            //currentAssembly.GetManifestResourceNames();
            string content = string.Empty;
            string templateName = "EntityTemplate.txt";
            using (Stream stream = currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.files.{templateName}"))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }

            content = content.Replace("{ModelsNamespace}", Helper.nameSpace)
               .Replace("{ModelClassName}", table.CSharpName)
               .Replace("{DbTableName}", table.Name)
               .Replace("{ModelProperties}", sb.ToString());

            string path = Helper.path + "\\" + table.CSharpName + ".cs";
            CodeGenerator.WriteAndSave(path, content);
        }

    }

    public class Oracle : IDB
    {
        public List<Table> GetTableAll(DbConnection conn)
        {
            List<Table> tables = new List<Table>();

            OracleCommand com = new OracleCommand("select table_name from user_tables", (OracleConnection)conn);
            OracleDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                tables.Add(new Table
                {
                    Name = reder["TABLE_NAME"].ToString()
                });
            }

            tables.ForEach(i =>
            {
                i.CSharpName = Helper.upString(i.Name);
            });

            return tables;
        }

        public List<TableColumn> GetTableColumn(DbConnection conn, Table table)
        {
            OracleCommand com = new OracleCommand($@"select t.TABLE_NAME,
                                           t.COLUMN_NAME,
                                           t.DATA_TYPE,
                                           t.DATA_LENGTH,
                                           t.NULLABLE,
                                           t1.COMMENTS,
                                           t2.constraint_type
                                      from user_tab_columns t
                                      join user_col_comments t1
                                        on t.TABLE_NAME = '{table.Name}'
                                       and t1.TABLE_NAME = '{table.Name}'
                                       and t.COLUMN_NAME = t1.COLUMN_NAME
                                      left join(select col.COLUMN_NAME, con.CONSTRAINT_TYPE
                                                   from user_constraints con
                                                   join user_cons_columns col
                                                     on con.constraint_name = col.constraint_name
                                                    and con.constraint_type = 'P'
                                                    and col.table_name = '{table.Name}'
                                                    and con.table_name = '{table.Name}') t2
                                        on t.COLUMN_NAME = t2.column_name", (OracleConnection)conn);
            OracleDataReader reder = com.ExecuteReader();

            List<TableColumn> tableColumn = new List<TableColumn>();

            #region 反射动态赋值
            //Type type = typeof(TableColumn);
            //while (reder.Read())
            //{
            //    object obj = Activator.CreateInstance(type, null);
            //    foreach (var prop in type.GetProperties())
            //    {
            //        prop.GetCustomAttributes(typeof(ColumnAttribute), false);
            //        //prop.IsDefined(typeof(ColumnAttribute),false)
            //        foreach (var attr in prop.GetCustomAttributes(typeof(ColumnAttribute), false))
            //        {
            //            if (attr is ColumnAttribute)
            //            {
            //                ColumnAttribute ca = attr as ColumnAttribute;
            //                prop.SetValue(obj, reder[ca.Name].ToString());
            //            }
            //        }
            //    }
            //    tableColumn.Add((TableColumn)obj);
            //}
            #endregion
            while (reder.Read())
            {
                tableColumn.Add(new TableColumn
                {
                    TableName = reder["TABLE_NAME"].ToString(),
                    ColumnName = reder["COLUMN_NAME"].ToString(),
                    DataType = reder["DATA_TYPE"].ToString(),
                    DataLength = reder["DATA_LENGTH"].ToString(),
                    Nullable = reder["NULLABLE"].ToString(),
                    Comments = reder["COMMENTS"].ToString(),
                    ConstraintType = reder["CONSTRAINT_TYPE"].ToString()
                });
            }

            tableColumn.ForEach(i =>
            {
                i.CSharpName = Helper.upString(i.ColumnName);
            });
            return tableColumn;
        }

    }

}
