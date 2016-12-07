using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Sample.PCL
{
    public class StudentDirectoryService
    {

        public static StudentDirectory LoadStudentDirectory()
        {
            DatabaseManager dbManager = new DatabaseManager();
            ObservableCollection<Student> students = new ObservableCollection<Student>(dbManager.GetAllItems<Student>());
            StudentDirectory studentDirectory = new StudentDirectory();

            if (students.Any())
            { 
                studentDirectory.Students = students;
                return studentDirectory;
            }

            students = new ObservableCollection<Student>();

            string[] names = { "Jose", "Luis", "Fernando", "Alexa", "Reyna" };
            string[] lastNames = { "Villalba","Bustillos","Pacheco","Gutierrez","Cano","Tarango"};
            Random rdn = new Random(DateTime.Now.Millisecond);

            for(int i=0; i < 20; i++)
            {
                Student student = new Student();
                student.Name = names[rdn.Next(0,4)];
                student.LastName = lastNames[rdn.Next(0,5)];
                student.Group = rdn.Next(400, 410).ToString();
                student.StudentNumber = rdn.Next(123000, 123999).ToString();
                student.Average = rdn.Next(100, 1000) / 10;
                student.Key = i.ToString(); ;
                students.Add(student);
                dbManager.SaveValue<Student>(student);
            }
            studentDirectory.Students = students;
            return studentDirectory;
        }
    }
}
