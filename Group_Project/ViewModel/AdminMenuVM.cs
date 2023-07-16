using CommunityToolkit.Mvvm.ComponentModel;
using Desktop_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Desktop_App.Model.User;
using System.Windows.Data;
using Group_Project.View;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Security.Cryptography.X509Certificates;

namespace Group_Project.ViewModel
{
    public partial class AdminMenuVM : ObservableObject
    {

        public DataBaseContext context = new DataBaseContext();




        [ObservableProperty]
        public ObservableCollection<User> userList;


        [ObservableProperty]
        public string? userName;

        [ObservableProperty]
        public string? password;

        [ObservableProperty]
        public User user;

 


        public AdminMenuVM() {


            Load();





        } 


   


        [RelayCommand]
        private void removeUser(User user)
        {

            var vm = MessageBox.Show("Are you sure want to Delete", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {
                if (user.Role == UserRole.NormalUser)
                {

                    using (var context = new DataBaseContext())
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        Load();
                    }

                }
                else MessageBox.Show("Admin cannot be deleted");

            }
          
          
        }



        [RelayCommand]
        public void Load()
        {
            context = new DataBaseContext();
            var list = context.Users.ToList();
            userList = new ObservableCollection<User>(list);
            OnPropertyChanged(nameof(userList));
        }


        [RelayCommand]
        public void AddUser()
        {
            var addUserVM = new AddUserWindowVM();
            AddUserWindow window = new AddUserWindow(addUserVM);

            window.ShowDialog();

            if (addUserVM.User != null)
            {

                userList.Add(addUserVM.User);
                using (context = new DataBaseContext())
                {
                    context.Users.Add(addUserVM.User);
                    context.SaveChanges();
                    
                }

            }

        }

            [RelayCommand]
            public  void editUser(User user)
        {            
            
           
           
            if (user != null)
            {
                var editUserVM = new AddUserWindowVM(user);
                using (context = new DataBaseContext())
                {
                 
                    context.Users.Remove(user);
                    context.SaveChanges();
                }

                
               
                var window = new AddUserWindow(editUserVM);

                window.ShowDialog();


                using (var context = new DataBaseContext())
                {

                   
                    context.Users.Add(editUserVM.User);
                    context.SaveChanges();
                  
                    Load();
                }
              

            }
            else if (userList.Count == 0) MessageBox.Show("User list is Empty!!");
            else
            {
                MessageBox.Show("Please Select a User to edit");
            }
      

          
            }
        




        


    }

}

    
