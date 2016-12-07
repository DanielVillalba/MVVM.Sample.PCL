using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MVVM.Sample.PCL.View
{
    public partial class StudentDetailPage : ContentPage
    {
        private Student selectedStudent;
        public StudentDetailPage(Student selectedStudent)
        {
            InitializeComponent();
            this.selectedStudent = selectedStudent;
            btnCongrats.Clicked += BtnCongrats_Clicked;
            this.BindingContext = selectedStudent;
        }

        private void BtnCongrats_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.NameCongratsPage(selectedStudent));
        }
    }
}
