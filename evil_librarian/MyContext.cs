using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evil_librarian.Models;

namespace evil_librarian
{
    class MyContext : DbContext
    {

        public DbSet<People> Persons { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public MyContext(string filename) : base(new SQLiteConnection()
        {
            ConnectionString =
                new SQLiteConnectionStringBuilder()
                { DataSource = filename, ForeignKeys = true }
                    .ConnectionString
        }, true)
        {

        }

    }
}