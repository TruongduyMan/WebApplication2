using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Student
    {
        [Display (Name="Ma sinh vien")]
        public string MaSV { get; set; }
        [Display (Name ="Ho ten sinh vien")]
        public string HoTen { get; set; }
        [Display(Name ="Diem so")]
        public double DiemSo { get; set; }

        
        
    }
}
