using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateEntity.DataBase
{
    public class SqlServer : IDB
    {
        public List<Table> GetTableAll(DbConnection conn)
        {
            List<Table> tables = new List<Table>();

            SqlCommand com = new SqlCommand("SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U'", (SqlConnection)conn);
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                tables.Add(new Table
                {
                    Name = reder["NAME"].ToString()
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
            SqlCommand com = new SqlCommand($@"select t.TABLE_NAME,
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
                                        on t.COLUMN_NAME = t2.column_name", (SqlConnection)conn);
            SqlDataReader reder = com.ExecuteReader();

            List<TableColumn> tableColumn = new List<TableColumn>();

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
