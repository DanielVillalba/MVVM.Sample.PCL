using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Xamarin.Forms;
using MVVM.Sample.PCL.Droid.InterfaceImplementation;

[assembly:Dependency(typeof(SQLiteDroid))]
namespace MVVM.Sample.PCL.Droid.InterfaceImplementation
{
    class SQLiteDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TodosSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;

        }
    }
}