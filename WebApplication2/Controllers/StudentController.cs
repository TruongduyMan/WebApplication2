using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemoSync()
        {
            var demo = new Demo();
            var sw = new Stopwatch();
            sw.Start();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            sw.Stop();
            return Content($"Chay het {sw.ElapsedMilliseconds} ms");

        }

        public async Task<IActionResult>AAAA()
        {
            var demo = new Demo();
            var sw = new Stopwatch();
            sw.Start();
            var a = demo.Test01Async();
            var b= demo.Test02Async();
            var c = demo.Test03Async();
            sw.Stop();
            return Content($"Chay het {sw.ElapsedMilliseconds} ms");

        }
        string textfile = "student.txt";
        string jsonfile = "student.json";
        string textFullPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", textfile);
        string jsonFullPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", jsonfile);
        string logfile => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", logfile);
        [HttpPost]
        public IActionResult Index(Student student, string GhiFile)
        {
            if(GhiFile=="Ghi file text")
            {
                var data = new string[]
                {
                    student.MaSV,
                    student.HoTen,
                    student.DiemSo.ToString()
                };

            }
            else if(GhiFile=="Ghi file json")
            {
                var jsonString = JsonConvert.SerializeObject(student);
                System.IO.File.WriteAllText(jsonFullPath, jsonFullPath);
            }
            return View("Index");
        }

        public IActionResult DocFile(string loai)
        {
            Student st = new Student();
            try
            {
                if (loai == "text")
                {
                    var data = System.IO.File.ReadAllLines(textFullPath);
                    st.MaSV = data[0];
                    st.HoTen = data[1];
                    if (double.TryParse(data[2], out double tmp))
                    {
                        st.DiemSo = tmp;
                    }
                    //st.DiemSo = double.Parse(data[2]);


                }
                else if (loai == "json")
                {
                    var data = System.IO.File.ReadAllLines(jsonFullPath);
                    st = JsonConvert.DeserializeObject<Student>(data);
                }
            }
            catch (JsonReaderException ex)
            {
                using (var file = new StreamWriter(logfile, true))
                {
                    file.Write(ex.Message);
                }
            }
            catch(Exception ex)
            {

            }

            return View();
        }
    }
}
