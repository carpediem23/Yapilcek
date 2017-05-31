using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using SQLite;
using Yapilcek.Dependencies;
using Yapilcek.Droid.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection))]
namespace Yapilcek.Droid.Dependencies
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private const string filename = "todo.db3";

        public SQLiteConnection GetConnection()
        {
            string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
            return new SQLiteConnection(path);
        }
    }
}