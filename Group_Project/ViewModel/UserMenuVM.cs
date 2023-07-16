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
using static Desktop_App.Model.User;

namespace Group_Project.ViewModel
{
    public partial class UserMenuVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> studentList;

        [ObservableProperty]
        public ObservableCollection<Course> courseList;




        public DataBaseContext context = new DataBaseContext();


        public User CurrUser { get; set; }

        

        public UserMenuVM(string username)
        {


            var table = context.Courses;
            // Check if the table has any records
            bool isEmpty = !table.Any();

            if (isEmpty)
            {
                MessageBox.Show("Empty");
                context.Courses.Add(new Course("CE", "Computer Engineering", 120));
                context.Courses.Add(new Course("CEE", "Civil Engineering", 120));
                context.Courses.Add(new Course("ME", "Mechanical Engineering", 120));
                context.Courses.Add(new Course("EIE", "Electrical Engineering", 120));
                context.SaveChanges();
                Load();

            }


            using (DataBaseContext context = new DataBaseContext())
            {
               
                CurrUser = context.Users.FirstOrDefault(s => s.UserName == username);
                if (CurrUser == null)
                    MessageBox.Show("User with this user name has not found");
            }

            Load();

        }


        [RelayCommand]
        public void Load()
        {
            context = new DataBaseContext();
            var list = context.Students.ToList();
            var list2 = context.Courses.ToList();
            courseList = new ObservableCollection<Course>(list2);
            studentList = new ObservableCollection<Student>(list);
            OnPropertyChanged(nameof(studentList));
        }

        [RelayCommand]
        public void registerStudent()
        {

            var addStudentVM = new AddStudentWindowVM(CurrUser);
            AddStudentWindow window = new AddStudentWindow(addStudentVM);

            window.ShowDialog();

            if (addStudentVM.Student != null)
            {

                studentList.Add(addStudentVM.Student);
                using (context = new DataBaseContext())
                {
                    context.Students.Add(addStudentVM.Student);
                    
                    context.SaveChanges();

                }

            }
        }

        [RelayCommand]
        public void editStudent(Student student)
        {



            if (student != null)
            {
                var editStudentVM = new AddStudentWindowVM(student);
                using (context = new DataBaseContext())
                {

                    context.Students.Remove(student);
                    context.SaveChanges();
                }
                var window = new AddStudentWindow(editStudentVM);
                window.ShowDialog();

                using (var context = new DataBaseContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    Load();
                }
            }
           



        }

        [RelayCommand]
        public void deleteStudent(Student student)
        {

            var vm = MessageBox.Show("Are you sure want to delete user", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {
                using (var context = new DataBaseContext())
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    Load();
                }
            }
          

          
        }

        [RelayCommand]
        public void addNewCourse()
        {

            
            var vm = new AddCourseWindow();
            vm.Show();

        }
    }
}
