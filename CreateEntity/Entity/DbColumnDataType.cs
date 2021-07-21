namespace CreateEntity
{
    public class DbColumnDataType
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DatabaseType { get; set; }

        /// <summary>
        /// 数据库中对应的类型
        /// </summary>
        public string ColumnTypes { get; set; }
        /// <summary>
        /// C#中对应的类型
        /// </summary>
        public string CSharpType { get; set; }
    }
}
