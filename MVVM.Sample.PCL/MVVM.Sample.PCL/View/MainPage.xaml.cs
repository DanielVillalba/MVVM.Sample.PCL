using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.Sample.PCL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new StudentDirectoryVM();
            lvStudents.ItemSelected += LvStudents_ItemSelected1;
        }

        private void LvStudents_ItemSelected1(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedStudent = (Student)e.SelectedItem;
            if (selectedStudent == null)
                return;
            Navigation.PushAsync(new View.StudentDetailPage(selectedStudent));
            lvStudents.SelectedItem = null;
        }

    }
}
