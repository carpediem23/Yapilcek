using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yapilcek.Dependencies
{
    public interface IDatabaseConnection
    {
        SQLiteConnection GetConnection();
    }
}
