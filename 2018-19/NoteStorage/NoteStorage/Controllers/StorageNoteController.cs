using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NoteStorage.Controllers
{
    public class StorageNoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SaveNote(string name, string text, string oldName = null)
        {
            if (oldName != null)
                RemoveFile(oldName);
            SaveToFile(text, false, name);
            ViewData["Name"] = name;
            ViewData["Text"] = text;
            return View();
        }

        private void RemoveFile(string oldName) => System.IO.File.Delete(@"D:\MY WORK\infa\CSWEB\" + oldName);

        private void SaveToFile(string text, bool rewrite, string name = null)
        {
            var time = DateTime.Now;
            var filename = name + "_" + time.ToShortDateString().Replace('.', '-') + '-' + time.ToLongTimeString().Replace(':', '-') + ".txt";

            string writePath = @"D:\MY WORK\infa\CSWEB\" + filename;

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IActionResult NoteList()
        {
            GetNoteList();
            return View();
        }

        private void GetNoteList()
        {
            try
            {
                string[] arrText = Directory.GetFiles(@"D:\MY WORK\infa\CSWEB", "*.txt");
                for (int i = 0; i < arrText.Length; i++)
                {
                    arrText[i] = arrText[i].Remove(0, 22);
                }
                ViewBag.Arr = arrText;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IActionResult ExactNote(string noteName)
        {

            ViewData["note"] = noteName;
            GetFile(noteName);
            return View();
        }

        private string ToShortName(string fileName)
        {
            return fileName.Remove(fileName.Length - 24, 24);
        }

        private void GetFile(string fileName)
        {
            ViewData["fileName"] = ToShortName(fileName);
            try
            {
                var path = @"D:\MY WORK\infa\CSWEB\" + fileName;
                using (StreamReader sr = new StreamReader(path))
                {
                    ViewData["fileTXT"] = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public FileResult Download(string fileName)
        {
            var filePath = @"D:\MY WORK\infa\CSWEB\" + fileName;
            var fs = new FileStream(filePath, FileMode.Open);
            var userFile = ToShortName(fileName) + ".txt";
            var contentType = "application/text";
            return File(fs, contentType, userFile);
        }

        public IActionResult Edit(string fileName)
        {
            ViewData["note"] = fileName;
            GetFile(fileName);
            return View();
        }
    }
}