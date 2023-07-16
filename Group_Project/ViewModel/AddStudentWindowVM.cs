using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project.ViewModel
{
    public partial class AddStudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string? firstName;
        [ObservableProperty]
        public string? lastName;


        [ObservableProperty]
        public string? userName;

        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public double gpa;

        public Student? Student { get; private set; }
        public Action? CloseAction { get; internal set; }

        public Student? temp;

        public AddStudentWindowVM(Student u)
        {
            Student = u;
            temp = u;
            firstName = u.FirstName;
            lastName = u.LastName;
            age = u.Age;
            id = u.Id;
            gpa = u.Gpa;
            userName = u.UserName;







        }
        public AddStudentWindowVM(User u)
        {
           
            userName = u.UserName;








        }
        public AddStudentWindowVM()
        {






        }




        [RelayCommand]
        public void save()
        {

            if (Student == null)
            {

                Student = new Student()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gpa = gpa,
                    UserName = userName



                };


            }
            else
            {
                Student.Id = id;
                Student.FirstName = firstName;
                Student.LastName = lastName;
                Student.Age = age;
                Student.Gpa = gpa;
                Student.UserName = userName;





            }
            if (Student.FirstName == null) MessageBox.Show("First Name cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.LastName == null) MessageBox.Show("Last Name cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.Age == 0) MessageBox.Show("Invalid Age", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.Id == null) MessageBox.Show("please enter the Student ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {



                    CloseAction();
                




                Application.Current.MainWindow.Show();


            }
        }


        [RelayCommand]
        public void Cancel()
        {
            var vm = MessageBox.Show("Are you sure want to cancel", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {
                Student = temp;
                CloseAction();
                Application.Current.MainWindow.Show();
            }


        }

    }
}
