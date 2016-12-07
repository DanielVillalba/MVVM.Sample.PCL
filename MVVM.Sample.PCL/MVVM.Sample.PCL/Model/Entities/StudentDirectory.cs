using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Sample.PCL
{
    public class StudentDirectory: ObservableBaseObject
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { students = value; OnPropertyChanged(); }
        }
    }
}
