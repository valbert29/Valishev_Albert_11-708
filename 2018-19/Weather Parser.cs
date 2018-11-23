using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            JSonHelper();
            JSonHelper("Astrakhan");
        }

        public static void JSonHelper(string str = "kazan")
        {
            var httpWebRequest = 
                (HttpWebRequest)WebRequest.Create
                ("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22+"+str+"%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";//Можно GET
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //ответ от сервера
                var result = streamReader.ReadToEnd();

                //Сериализация
                RootObject отв = JsonConvert.DeserializeObject<RootObject>(result);
                Console.WriteLine(result);
                Console.WriteLine("------------");
                Console.WriteLine(отв.query.results.channel.location.city);
                Console.WriteLine("------------");
                var item = отв.query.results.channel.item.forecast;
                foreach (var elem in item)
                {
                    var stuf = JsonConvert.SerializeObject(elem);
                    Console.WriteLine(stuf);
                }

            }
            Console.ReadLine();
        }
    }
}
