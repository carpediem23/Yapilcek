using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Yapilcek.Dependencies;
using Windows.Storage;
using System.IO;
using Yapilcek.UWP.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection))]
namespace Yapilcek.UWP.Dependencies
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private const string filename = "todo.db3";

        public SQLiteConnection GetConnection()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            return new SQLiteConnection(path);
        }
    }
}
