using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SinhVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        string textfile = "student.txt";
        string jsonfile = "student.json";
        string textFullPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", textfile);
        string jsonFullPath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", jsonfile);
        [HttpPost]
        public IActionResult Index(Student student, string GhiFile)
        {
            if (GhiFile == "Ghi file text")
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
    }
}
