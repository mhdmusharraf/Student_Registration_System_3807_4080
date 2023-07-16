using CommunityToolkit.Mvvm.Input;
using Desktop_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;
using Microsoft.EntityFrameworkCore;
using Group_Project.View;
using static Desktop_App.Model.User;

namespace Group_Project.ViewModel
{
    public partial class AddCourseWindowVM : ObservableObject
    {

    
        public Course? Course { get; internal set; }


        public DataBaseContext context = new DataBaseContext();



        [ObservableProperty]
        public ObservableCollection<Course> courses;


        [ObservableProperty]
        public string? courseId;

        [ObservableProperty]
        public string? courseName;

        [ObservableProperty]
        public int credits;



        [RelayCommand]
        
        public void AddCourse()
        {
            var editcourseVM = new EditCourseWindowVM();
            EditCourseWindow window = new EditCourseWindow(editcourseVM);

            window.ShowDialog();

            if (editcourseVM.Course != null)
            {

                courses.Add(editcourseVM.Course);
                using (context = new DataBaseContext())
                {
                    context.Courses.Add(editcourseVM.Course);
                    context.SaveChanges();

                }

            }

        }


        [RelayCommand]
        public void editCourse(Course course)
        {



            if (course != null)
            {
                var editcoursevm = new EditCourseWindowVM(course);
                using (context = new DataBaseContext())
                {

                    context.Courses.Remove(course);
                    context.SaveChanges();
                }



                var window = new EditCourseWindow(editcoursevm);

                window.ShowDialog();


                using (var context = new DataBaseContext())
                {


                    context.Courses.Add(editcoursevm.Course);
                    context.SaveChanges();

                    Load();
                }


            }
        }

        [RelayCommand]
        private void removeCourse(Course course)
        {

            var vm = MessageBox.Show("Are you sure want to Delete", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {

                using (var context = new DataBaseContext())
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                    Load();
                }

                

            }


        }


        [RelayCommand]
        public void Load()
        {
            context = new DataBaseContext();
            var list = context.Courses.ToList();
            courses = new ObservableCollection<Course>(list);
            OnPropertyChanged(nameof(courses));
        }


      

        public AddCourseWindowVM()
        {
            Load();
        }

    }
}
