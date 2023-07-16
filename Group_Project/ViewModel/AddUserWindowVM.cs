using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace Group_Project.ViewModel
{
    public partial class AddUserWindowVM : ObservableObject
    {

        [ObservableProperty]
        public string? userName;
        [ObservableProperty]
        public string? password;

        [ObservableProperty]
        public User.UserRole role;


        public User User { get; private set; }
        public Action CloseAction { get; internal set; }



        public User temp;



        public AddUserWindowVM(User u)
        {
            User = u;
            temp = u;     
            userName = u.UserName;
            password = u.Password;
            role = u.Role;
            
            




        }
        public AddUserWindowVM()
        {
           

        }



     


        [RelayCommand]
        public void save()
        {

            if (User == null)
            {

                User = new User()
                {
                    UserName = userName,
                    Password = password,
                    Role = User.UserRole.NormalUser
                    

                };


            }
            else
            {

                User.UserName = userName;
                User.Password = password;
                User.Role = role;
              



            }
            if (User.UserName == null) MessageBox.Show("User Name cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (User.Password == null) MessageBox.Show("Password cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            bool existingUser;
            using (var context = new DataBaseContext())
            {
                 existingUser = context.Users.Any(u => u.UserName == User.UserName);
            }
            if (existingUser)
            {
                MessageBox.Show("User Name Already Exists");
                role = User.UserRole.NormalUser;


            }
            
            else
            {

                CloseAction();
            }




            Application.Current.MainWindow.Show();


        }


        [RelayCommand]
        public void Cancel()
        {
            var vm = MessageBox.Show("Are you sure want to cancel", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {
                User = temp;
                CloseAction();
                Application.Current.MainWindow.Show();
            }


        }
    }

}
