using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Yapilcek.Dependencies;
using Yapilcek.Models.Domains;

namespace Yapilcek.Providers
{
    public class DatabaseProvider
    {
        private static DatabaseProvider instance;
        private SQLiteConnection database;
        public static DatabaseProvider Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseProvider();
                }

                return instance;
            }
        }

        public DatabaseProvider()
        {
            database = DependencyService.Get<IDatabaseConnection>().GetConnection();
            database.CreateTable<Todo>();
        }

        public List<Todo> GetAll()
        {
            return database.Table<Todo>().ToList<Todo>();
        }

        public Todo Get(int id)
        {
            return database.Table<Todo>().Where<Todo>(t => t.TodoId == id).FirstOrDefault<Todo>();
        }

        public void Create(Todo todo)
        {
            database.Insert(todo);
        }

        public void Update(Todo todo)
        {
            database.Update(todo);
        }

        public void Delete(int id)
        {
            Todo todo = Get(id);
            database.Delete<Todo>(id);
        }

        public void DeleteAll()
        {
            database.DeleteAll<Todo>();
        }
    }
}
