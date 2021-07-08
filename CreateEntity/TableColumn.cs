using System.ComponentModel.DataAnnotations.Schema;

namespace CreateEntity
{
    public class Table
    {
        public string Name { get; set; }
        public string CSharpName { get; set; }
    }

    public class TableColumn
    {
        /// <summary>
        /// 表名
        /// </summary>
        [Column("TABLE_NAME")]
        public string TableName { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        [Column("COLUMN_NAME")]
        public string ColumnName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        [Column("DATA_TYPE")]
        public string DataType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        [Column("DATA_LENGTH")]
        public string DataLength { get; set; }
        /// <summary>
        /// 允许为空Y/N
        /// </summary>
        [Column("NULLABLE")]
        public string Nullable { get; set; }
        /// <summary>
        /// 字段注释
        /// </summary>
        [Column("COMMENTS")]
        public string Comments { get; set; }
        /// <summary>
        /// 主键标签 P
        /// </summary>
        [Column("CONSTRAINT_TYPE")]
        public string ConstraintType { get; set; }

        public string CSharpType { get; set; }
        public string CSharpName { get; set; }

    }
}
