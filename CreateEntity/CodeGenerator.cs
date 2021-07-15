using System.IO;
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

            sb.AppendLine("\t\t/// <summary>");
            sb.AppendLine("\t\t/// " + column.Comments);
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
                string comments = column.Comments;
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
