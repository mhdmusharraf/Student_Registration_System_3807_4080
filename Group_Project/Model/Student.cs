using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_App.Model
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       // public Course? CourseEnrolled { get; set; }
        public int Age { get; set; }
        public double Gpa { get; set; }


        public string UserName { get; set; } //Foreign Key

        public virtual User User { get; set; }

        public Student()
        {
        }

        public Student(int id, string? firstName, string? lastName, /*Course? courseEnrolled*/ int age, double gpa)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        //  CourseEnrolled = courseEnrolled;
            Age = age;
            Gpa = gpa;
        }
    }
}
