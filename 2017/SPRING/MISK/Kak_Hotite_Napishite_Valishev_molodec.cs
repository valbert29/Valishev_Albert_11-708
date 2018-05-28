using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace Reflection
{
    public class Pictures
    {
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

    }

    public class Comments
    {
        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    class Program
    {
        public static void Main()
        {
            var client = new WebClient();
            var url = client.DownloadString(@"https://jsonplaceholder.typicode.com/photos");
            var arrOfPics = JsonConvert.DeserializeObject<Pictures[]>(url);
            //DownloadPictures(arrOfPics);
            PropertiesValue(arrOfPics);
        }

        static void DownloadPictures(Pictures[] arrOfPics)
        {
            //лист поток
            var list = new List<Task>();
            foreach (var i in arrOfPics)
            {
                //создаем клиент
                WebClient webClien = new WebClient();
                var PicName = Path.GetFileName(i.ThumbnailUrl);
                //через TaskAsync скачиваем
                list.Add(webClien.DownloadFileTaskAsync(i.ThumbnailUrl, $"{PicName}.png"));
            }
            //Ждём, пока все потоки завершатся
            Task.WaitAll(list.ToArray());
        }

        static void PropertiesValue(Pictures[] pictureArr)
        {
            var product = pictureArr.FirstOrDefault();
            foreach (var item in product.GetType().GetProperties())
            {
                int k = 0;
                var pattern = "bcdfghjklmnpqrstvw";//тут чекаем согласные
                for (int i = 0; i < item.Name.Length; i++)
                {
                    if (pattern.Contains(item.Name.ToLower()[i]))
                        k++;
                }
                if (k % 2 == 0) Console.WriteLine(item.Name);//если четное колв-о слов
            }
        }

        static long Count = 0;//для общего счета слов в комменте
        static object obj = new object();//для lock в инете посмотрел

        static void Comments()
        {
            var client = new WebClient();
            var list = new List<Task>();//лист для потоков
            var str = client.DownloadString(@"https://jsonplaceholder.typicode.com/comments?postId=1");
            var commentsArr = JsonConvert.DeserializeObject<Comments[]>(str);
            foreach (var item in commentsArr)
            {
                if (item.Id % 2 == 0)//айди 2
                {
                    var task = new Task(() => CountLetter(item.Body.Split(' ', '\n')));//массив слов
                    task.Start();
                    list.Add(task);

                }
            }
            Task.WaitAll(list.ToArray());
            Console.WriteLine(Count);
        }

        static void CountLetter(string[] array)
        {
            var count = 0;
            foreach (var item in array)
            {
                count += item.Length;//добавим длину слов
            }
            lock(obj)
                Count += count;//и общее длину строки

        }
    }
}
