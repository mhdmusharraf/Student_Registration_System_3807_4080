using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_App.Model;
using Group_Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project.ViewModel
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string? userName;
        [ObservableProperty]
        public string? password;

        [ObservableProperty]
        ObservableCollection<User> userList;




        public MainWindowVM()
        {



            using (var context = new DataBaseContext())
            {
                

            }

           



        }





        [RelayCommand]
        public void adminLogin()
        {


            if (userName == "admin" && password == "123")
            {
                var adminmenu = new AdminMenu();
                adminmenu.Show();
            }

            else MessageBox.Show("Invalid User Name or Password");





        }

        [RelayCommand]
        public void userLogin()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var curruser = context.Users.FirstOrDefault(St => St.UserName == userName && St.Password == password);

                if (curruser != null && curruser.Role == User.UserRole.NormalUser)
                {
                    // var studentMainViewModel = new StudentMainVM(currstudent.Id);
                    //  var resultDetailsVM = new ResultsDetailsVM(currstudent);
                    var userMenuvm = new UserMenuVM(curruser.UserName);
                    var usermenu = new UserMenu(userMenuvm);
                    usermenu.Show();
                }
                else
                {
                    MessageBox.Show("UserName or Password is Incorrect");
                }

            }


           
        }
    
}
}
