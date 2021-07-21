using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data.Common;

namespace CreateEntity
{
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
