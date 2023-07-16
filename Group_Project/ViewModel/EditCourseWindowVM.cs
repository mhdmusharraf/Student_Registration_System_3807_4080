using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Group_Project.ViewModel
{
   public partial  class EditCourseWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string courseName;
        [ObservableProperty]
        public string courseId;
        [ObservableProperty]
        public int credits;

        



        public Course Course { get; private set; }
        public Course temp { get; private set; }

        public Action CloseAction { get; internal set; }

        public EditCourseWindowVM(Course u)
        {
            Course = u;
            temp = u;
            courseName = u.CourseName;
            CourseId = u.CourseId;
            credits = u.Credits;
        }

        public EditCourseWindowVM()
        {


        }

        [RelayCommand]
        public void save()
        {


            Course = new Course()
            {

                CourseId = courseId,
                CourseName = courseName,
                Credits = credits


            };




            if (Course.CourseId == null) MessageBox.Show("Course ID  cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Course.CourseName == null) MessageBox.Show("Course Name cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Course.Credits == 0) MessageBox.Show("Enter valid Course Credits", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {


                bool existingCourse;
                using (var context = new DataBaseContext())
                {
                    existingCourse = context.Courses.Any(u => u.CourseId == Course.CourseId);
                }
                if (existingCourse)
                {
                    MessageBox.Show("Course ID Already Exists");



                }

                else
                {

                    CloseAction();
                }




                Application.Current.MainWindow.Show();

            }
            
        }
        [RelayCommand]
        public void Cancel()
        {
            var vm = MessageBox.Show("Are you sure want to cancel", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {
                Course = temp;
                CloseAction();
                Application.Current.MainWindow.Show();
            }


        }



    }
}
