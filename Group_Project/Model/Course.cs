using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_App.Model
{
    public class Course
    {

        [Key]
        public string CourseId { get; set; }
        public string? CourseName { get; set; }
        public int Credits { get; set; }
        //public List<Module>? Modules { get;}

        public Course(string id,string? courseName, int credits) /*List<Module>? modules*/
        {

            CourseId = id;
            CourseName = courseName;
            Credits = credits;
          //  Modules = modules;
        }

        

        public Course()
        {
        }
    }
}
