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
            SqlCommand com = new SqlCommand($@"SELECT 
                                                表名       = d.name,--case when a.colorder=1 then d.name else '' end,
                                                --表说明     = case when a.colorder=1 then isnull(f.value,'') else '' end,
                                                --字段序号   = a.colorder,
                                                字段名     = a.name,
                                                --标识       = case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,
                                                主键       = case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (
                                                                 SELECT name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then 'P' else null end,
                                                类型       = b.name,
                                                占用字节数 = a.length,
                                                --长度       = COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                                                --小数位数   = isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                                                允许空     = case when a.isnullable=1 then 'Y'else 'N' end,
                                                --默认值     = isnull(e.text,''),
                                                字段说明   = g.[value]
                                            FROM syscolumns a
                                            left join systypes b on a.xusertype=b.xusertype
                                            inner join sysobjects d on a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'
                                            left join syscomments e on a.cdefault=e.id
                                            left join sys.extended_properties g on a.id=G.major_id and a.colid=g.minor_id  
                                            left join sys.extended_properties f on d.id=f.major_id and f.minor_id=0
                                            where d.name='{table.Name}'
                                            order by  a.id,a.colorder", (SqlConnection)conn);
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
