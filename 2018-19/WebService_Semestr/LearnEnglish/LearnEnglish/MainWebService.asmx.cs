using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace LearnEnglish
{
    /// <summary>
    /// Сводное описание для MainWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class MainWebService : WebService, IFunctional
    {
        //нажата ли кнопка Start
        public bool IsStarted { get; set; }
        public int CorrectAnswCounter { get; private set; }
        
        public void IncrCorAnswCount()
        {
            CorrectAnswCounter++;
        }

        
        private static List<string> Questions { get; set; } = null;

        public List<string> InitQuestions()
        {
            if (Questions == null)
            {
                return Questions = GetTask();
            }
            else return Questions;
        }

        readonly private static string connection_str = "Data Source=(local);Initial Catalog=LearnGame;Persist Security Info=True;Trusted_Connection=True;";

        public List<string> GetTask()
        {
            List<string> result = new List<string>();

            using (SqlConnection connection = new SqlConnection(connection_str))
            {
                var select = "SELECT t.question FROM TestQuest t";
                SqlCommand command = new SqlCommand(select, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader[i].ToString());
                            }

                        }
                    }
                }
                catch (Exception e) { return new List<string> { e.Message }; }                
            }
            return result;
        }

        //перемешивает значения, чтобы игра не была предсказуемой
        private List<Tuple<string, int>> ShuffleData(List<Tuple<string, int>> data)
        {
            var rnd = new Random();
            for (var i = data.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }
            return data;
        }

        private List<Tuple<string, int>> ConfigForCurrentQuest(int quest_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_str))
            {
                var unCorAns = @"select av1.answer from(select avs.var_id from AnswValues avs
                Except
                select av.var_id from AnswVars av) p join AnswValues av1 on p.var_id=av1.var_id;";
                var corAnsw = $"select av1.answer from (select av.var_id from AnswVars av where av.quest_id = {quest_id}) p join AnswValues av1 on p.var_id=av1.var_id;";
                var res = new List<Tuple<string, int>>();
                SqlCommand correctAnsw = new SqlCommand(corAnsw, connection);
                SqlCommand uncorrectAnsw = new SqlCommand(unCorAns, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = correctAnsw.ExecuteReader())
                    {
                        while(reader.Read())
                            res.Add(Tuple.Create(reader[0].ToString(),1));
                    }

                    using (SqlDataReader uncorReader = uncorrectAnsw.ExecuteReader())
                    {
                        var uncorVars = new List<string>();
                        while (uncorReader.Read())
                        {
                            for (int i = 0; i < uncorReader.FieldCount; i++)
                            {
                                uncorVars.Add(uncorReader[i].ToString());
                                
                            }
                        }
                        res.AddRange(GetUncorrectValues(uncorVars));
                    }
                }
                catch (Exception e) { return new List<Tuple<string, int>> { Tuple.Create(e.Message, 0) }; }
                return res;
            }
        }
        
        //получить неверные варианты ответа
        private List<Tuple<string, int>> GetUncorrectValues(List<string> allValues)
        {
            var helper = new List<string>();
            var rnd = new Random();
            var res = new List<Tuple<string, int>>();
            for (int i = 0; i < 3; i++)
            {
                var next = rnd.Next(0, 48);
                if (!helper.Contains(allValues[next]))
                {
                    helper.Add(allValues[next]);
                    res.Add(Tuple.Create(allValues[next], 0));
                }
                else i--;
            }
            return res;
        }

        //для последовательной выдачи вопросов
        public int questCounter = 0;
        public string GetNextQuest(List<string> questions)
        {
            if(questCounter<questions.Count)
                return questions[questCounter++];
            return "";
        }

        private List<Tuple<string, int>> CurrentConfig = new List<Tuple<string, int>>();
        private List<Tuple<string, int>> LastConfig = new List<Tuple<string, int>>();
        public List<Tuple<string, int>> GetCurrConfiguration()
        {
            LastConfig = CurrentConfig;
            return CurrentConfig = ShuffleData(ConfigForCurrentQuest(questCounter+1));
        }

        public void CheckAnswCorrctness(string item)
        {
            if (!LastConfig.Where(x => x.Item2 == 0).Select((x) => x.Item1).ToArray().Contains(item))
            {
                IncrCorAnswCount();
            }
        }
    }
}
