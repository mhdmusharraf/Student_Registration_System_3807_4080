using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_App.Model
{
    public class User
    {
        [Key]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Student> Students { get; set; }
        public enum UserRole
        {
            Admin,
            NormalUser
        }


        public string UserType { 
            get { if (Role == UserRole.Admin) return "Admin";
                else return "Normal User";
            }  }
        public User()
        {
        }

        public User(string? userName, string? password, UserRole role)
        {
           
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
