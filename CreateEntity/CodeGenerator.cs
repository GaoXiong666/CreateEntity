using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CreateEntity
{
    public class CodeGenerator
    {

        /// <summary>
        /// 生成属性
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="column">列</param>
        /// <returns></returns>
        public static string GenerateEntityProperty(TableColumn column)
        {
            StringBuilder sb = new StringBuilder();

            //字符集不匹配的话乱码可能会出现换行符号，导致排版混乱或报错
            string comments = column.Comments.Replace("\n", "").Replace("\r", "");

            sb.AppendLine("\t\t/// <summary>");
            sb.AppendLine("\t\t/// " + comments);
            sb.AppendLine("\t\t/// </summary>");

            if (column.ConstraintType == "P")
            {
                sb.AppendLine("\t\t[Key]");
            }

            sb.AppendLine($"\t\t[Column(\"{column.ColumnName}\")]");

            //if (column.Nullable=="N")
            //{
            //    sb.AppendLine($"\t\t[Required(ErrorMessage = \"{column.Comments ?? column.ColumnName}不允许为空\")]\n");
            //}
            if (column.CSharpType == "string")
            {
                if (string.IsNullOrEmpty(comments))
                {
                    comments = column.CSharpName;
                }
                sb.AppendLine($"\t\t[StringLength({column.DataLength}, ErrorMessage = \"{comments}长度不能超出{column.DataLength}字符\")]");
            }


            string colType = column.CSharpType;
            if (colType != "string" && colType != "byte[]" && column.Nullable == "Y")
            {
                colType = colType + "?";
            }

            sb.AppendLine($"\t\tpublic {colType} {column.CSharpName} " + "{ get; set; }");

            return sb.ToString();
        }

        /// <summary>
        /// 生成实体类文件
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        public static void BuildEntityClass(Table table, List<TableColumn> columns)
        {
            columns.ForEach(x =>
            {
                string csharpType = DataTypeMapping.dbColumnDataTypes.FirstOrDefault(t =>
                        t.DatabaseType == Helper.dbType && t.ColumnTypes.Split(',').Any(p =>
                            p.Trim().Equals(x.DataType, StringComparison.OrdinalIgnoreCase)))?.CSharpType;
                if (string.IsNullOrEmpty(csharpType))
                {
                    throw new Exception($"未从字典中找到\"[{x.TableName}]表 [{x.ColumnName}]字段 {x.DataType}\"类型，对应的C#数据类型");
                }

                x.CSharpType = csharpType;
            });

            //生成属性
            StringBuilder sb = new StringBuilder();
            foreach (TableColumn column in columns)
            {
                string tmp = GenerateEntityProperty(column);
                sb.AppendLine(tmp);
            }

            string content = GetTemplateContext("EntityTemplate.txt");
            
            content = content.Replace("{Namespace}", Helper.nameSpace)
               .Replace("{ClassName}", table.CSharpName)
               .Replace("{TableName}", table.Name)
               .Replace("{Properties}", sb.ToString());

            string path = Helper.path + "\\" + table.CSharpName + ".cs";
            WriteAndSave(path, content);
        }

        /// <summary>
        /// 生成EFCoreDbContext文件，和Entity文件在同一路径下
        /// </summary>
        /// <param name="tables"></param>
        public static void BuildEFCoreDbContext(List<Table> tables)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var table in tables)
            {
                sb.AppendLine($"\t\tpublic virtual DbSet<{table.CSharpName}> {table.CSharpName} " + "{ get; set; }");
            }

            string content = GetTemplateContext("EFCoreDbContext.txt");

            content = content.Replace("{Namespace}", Helper.nameSpace)
               .Replace("{ClassName}", Helper.DbContextName)
               .Replace("{ConStr}", $"optionsBuilder.Use{Helper.dbType}(\"{Helper.conStr}\");")
               .Replace("{Tables}", sb.ToString());

            string path = Helper.path + $"\\{Helper.DbContextName}.cs";
            WriteAndSave(path, content);
        }

        /// <summary>
        /// 获取模板文件内容
        /// </summary>
        /// <param name="templateName">模板名</param>
        /// <returns></returns>
        public static string GetTemplateContext(string templateName)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            using (Stream stream = currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.files.{templateName}"))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName">文件完整路径</param>
        /// <param name="content">内容</param>
        public static void WriteAndSave(string fileName, string content)
        {
            //实例化一个文件流--->与写入文件相关联
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                //实例化一个StreamWriter-->与fs相关联
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    //开始写入
                    sw.Write(content);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
}
