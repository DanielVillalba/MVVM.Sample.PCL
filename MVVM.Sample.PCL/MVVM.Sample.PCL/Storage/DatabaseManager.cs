using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.Sample.PCL
{
    public interface IKeyObject
    {
        string Key { get; set; }
    }

    public class DatabaseManager
    {
        SQLiteConnection database;

        public DatabaseManager()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Student>();
        }

        public void SaveValue<T>(T value) 
            where T:IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 0)
                database.Insert(value);
            else
                database.Update(value);
        }

        public void DeleteValue<T>(T value) 
            where T:IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                database.Delete(value);
            else
                throw new Exception("The data base does not contain an entry with the specified key");
        }


        public List<T> GetAllItems<T>()
            where T:IKeyObject, new()
        {
            return database.Table<T>().AsEnumerable<T>().ToList();
        }

        public T GetItem<T>(string key)
            where T:IKeyObject, new()
        {
            var result = (from entry in database.Table<T>().AsEnumerable<T>()
                          where entry.Key == key
                          select entry).FirstOrDefault();

            return result;
        }
    }
}
