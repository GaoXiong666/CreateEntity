using System.Collections.Generic;

namespace CreateEntity
{
    public static class DataTypeMapping
    {
        public static IList<DbColumnDataType> dbColumnDataTypes => new List<DbColumnDataType>
        {
            #region Oracle, https://docs.oracle.com/cd/E14435_01/win.111/e10927/featUDTs.htm#CJABAEDD
            //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/oracle-data-type-mappings
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "BFILE,BLOB,RAW,LONG RAW", CSharpType = "byte[]"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "CHAR, NCHAR, VARCHAR2, CLOB, NCLOB,NVARCHAR2,REF,XMLTYPE,ROWID,LONG", CSharpType = "string"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "BINARY FLOAT,BINARY DOUBLE", CSharpType = "byte"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "INTERVAL YEAR TO MONTH", CSharpType = "int"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "FLOAT,INTEGER,NUMBER", CSharpType = "decimal"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "DATE,TIMESTAMP,TIMESTAMP WITH LOCAL TIME ZONE,TIMESTAMP WITH TIME ZONE", CSharpType = "DateTime"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "INTERVAL DAY TO SECOND", CSharpType = "TimeSpan"},
            new DbColumnDataType() { DatabaseType = DataBaseType.Oracle, ColumnTypes = "INTERVAL YEAR TO MONTH", CSharpType = "long"},
            #endregion
        };
    }
}
