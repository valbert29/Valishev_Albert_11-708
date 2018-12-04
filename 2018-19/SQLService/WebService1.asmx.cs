using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebService
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }
        [WebMethod]
        public List<string> GetTableList()
        {
            List<string> result = new List<string>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable table = connection.GetSchema("Tables");
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(row[2].ToString());
                    }
                }
                catch (Exception e){ return new List<string> { "произошёл Exception" };}
                    return result;                
            }
        }
        [WebMethod]
        public List<string> GetTableColumns(string table)
        {
            if (GetTableList().Contains(table))
            {
                List<string> result = new List<string>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine();
                    var select = "SELECT * FROM " + table;
                    SqlCommand command = new SqlCommand(select, connection);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader.GetName(i));
                            }
                        }
                    }
                    catch (Exception e) { return new List<string> { "Неверная команда" }; }
                    return result;
                }
            }
            return new List<string> { "Обнаружена Инъекция или Таблица не найдена" };
        }
        [WebMethod]
        public List<string> GetTableValues(string table, string where)
        {
            List<string> result = new List<string>();
            if (GetTableList().Contains(table.Split(' ')[0]))
            {
                where = SqlInjection(where);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var select = $"SELECT * FROM {table} WHERE {where}";
                        SqlCommand command = new SqlCommand(select, connection);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    result.Add(reader[i].ToString());
                                }
                            }
                        }
                                                   
                    }
                    catch (Exception e) { return new List<string> { "Неверная команда" }; }
                    return result;
                }
            }
            return new List<string> { "Произошла Инъекция или таблица не существует" };
        }

        public string SqlInjection(string injection)
        {
            var i = 99999999;
            var stuf = new[] { "/*", "--", ";" };
            foreach (var item in stuf)
            {
                if (injection.Contains($"{item}"))
                {
                    var c = injection.IndexOf($"{item}");
                    if (c < i)
                        i = c;
                    if (!CheckIn(injection, i)) break;
                    else i += 2;
                }
            }
            return (i != 99999999)? injection.Substring(0, i): injection;
        }
        private bool CheckIn(string injection, int i)
        {
            var fI = new List<int>();
            while (injection.Contains('\''))
            {
                var count = injection.IndexOf('\'');
                fI.Add(count);
                 injection = injection.Remove(count, 1);
            }

            return (fI.Count >= 2 && i > fI[0] && i <= fI[1]);
        }
    }
}
