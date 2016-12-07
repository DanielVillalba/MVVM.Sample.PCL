using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MVVM.Sample.PCL.View
{
    public partial class NameCongratsPage : ContentPage
    {
        public NameCongratsPage(Student selectedStudent)
        {
            InitializeComponent();
            this.BindingContext = selectedStudent;
        }
    }
}
