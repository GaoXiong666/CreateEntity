﻿using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CreateEntity
{
    public static class Helper
    {
        public const string lable = "实体生成器";
        public static DataBaseType dbType;
        public static string nameSpace;
        public static string path;
        public static string conStr;
        /// <summary>
        /// 是否替换现有文件,true替换,false不替换
        /// </summary>
        public static bool IsReplace = false;
        /// <summary>
        /// 是否生成上下文,true生成,false不生成
        /// </summary>
        public static bool IsDbContext = false;
        public static string DbContextName;

        /// <summary>
        /// 将首字母和带 _ 后第一个字母 转换成大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string upString(string str)
        {
            StringBuilder sb = new StringBuilder();
            if (str.Contains('_'))
            {
                string[] split = str.Split('_');
                foreach (string st in split)
                {
                    string str1 = upString(st);
                    sb.Append(str1);
                }
            }
            else
            {
                char[] chr = str.ToLower().ToCharArray();
                if (chr[0] >= 'a' && chr[0] <= 'z')
                {
                    // 利用ASCII码实现首字母大写
                    chr[0] = (char)(chr[0] - 32);
                }
                sb.Append(chr);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetDbConnection()
        {
            DbConnection conn = null;
            if (dbType == DataBaseType.Oracle)
            {
                conn = new OracleConnection(conStr);
            }
            else if (dbType == DataBaseType.SqlServer)
            {
                conn = new SqlConnection(conStr);
            }
            else if (dbType == DataBaseType.MySQL)
            {
                conn = new MySqlConnection(conStr);
            }
            return conn;
        }
    }
}
