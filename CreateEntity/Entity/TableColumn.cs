namespace CreateEntity
{
    public class TableColumn
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string DataLength { get; set; }
        /// <summary>
        /// 允许为空Y/N
        /// </summary>
        public string Nullable { get; set; }
        /// <summary>
        /// 字段注释
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 主键标签 P
        /// </summary>
        public string ConstraintType { get; set; }

        public string CSharpType { get; set; }
        public string CSharpName { get; set; }

    }
}
