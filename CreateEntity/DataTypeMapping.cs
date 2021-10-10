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

            #region SqlServer，https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
            
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "bigint", CSharpType = "long"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "binary,image,varbinary(max),rowversion,timestamp,varbinary", CSharpType = "byte[]"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "bit", CSharpType = "bool"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "char,nchar,text,ntext,varchar,nvarchar,xml", CSharpType = "string"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "date,datetime,datetime2,smalldatetime", CSharpType ="DateTime"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "datetimeoffset", CSharpType ="DateTimeOffset"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "decimal,money,numeric,smallmoney", CSharpType ="decimal"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "float", CSharpType ="double"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "int", CSharpType ="int"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "real", CSharpType ="float"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "smallint", CSharpType ="short"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "sql_variant", CSharpType ="object"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "time", CSharpType ="TimeSpan"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "tinyint", CSharpType ="byte"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.SqlServer, ColumnTypes = "uniqueidentifier", CSharpType ="Guid"},

            #endregion

            #region MySQL，https://www.devart.com/dotconnect/mysql/docs/DataTypeMapping.html

            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "bool,boolean,bit(1),tinyint(1)", CSharpType ="bool"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "tinyint", CSharpType ="sbyte"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "tinyint unsigned", CSharpType ="byte"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "smallint, year", CSharpType ="short"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "int, integer, smallint unsigned, mediumint", CSharpType ="int"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "bigint, int unsigned, integer unsigned, bit", CSharpType ="long"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "float", CSharpType ="float"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "double, real", CSharpType ="double"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "decimal, numeric, dec, fixed, bigint unsigned, float unsigned, double unsigned, serial", CSharpType ="decimal"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "date, timestamp, datetime", CSharpType ="DateTime"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "datetimeoffset", CSharpType ="DateTimeOffset"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "time", CSharpType ="TimeSpan"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "char, varchar, tinytext, text, mediumtext, longtext, set, enum, nchar, national char, nvarchar, national varchar, character varying", CSharpType ="string"},
            new DbColumnDataType(){ DatabaseType = DataBaseType.MySQL, ColumnTypes = "binary, varbinary, tinyblob, blob, mediumblob, longblob, char byte", CSharpType ="byte[]"}

            #endregion
        };
    }
}
