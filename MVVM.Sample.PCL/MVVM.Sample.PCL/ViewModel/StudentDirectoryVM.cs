using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.Sample.PCL
{
    public class StudentDirectoryVM :ObservableBaseObject
    {
        public ObservableCollection<Student> Students { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public Command LoadDirectoryCommand { get; set; }

        public StudentDirectoryVM()
        {
            Students = new ObservableCollection<Student>();
            IsBusy = false;
            LoadDirectoryCommand = new Command((obj) => LoadDirectory());
        }

        async private void LoadDirectory()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Task.Delay(3000);

                var loadedDirectory = StudentDirectoryService.LoadStudentDirectory();

                foreach(Student student in loadedDirectory.Students)
                {
                    Students.Add(student);
                }

                IsBusy = false;
            }
        }
    }
}
