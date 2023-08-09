using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Student
    {
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }
        public int Student_Phone { get; set; }
        public string Student_Class { get; set; }
        public string Student_Email { get; set; }
    }
}