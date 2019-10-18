using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using evil_librarian.Models;

namespace evil_librarian
{
    class DataAccessLayer
    {
        private string ConnectionPath { get; }

        public DataAccessLayer(string connectionPath)
        {
            ConnectionPath = connectionPath;
        }

        public void CreateDataBase()
        {


            using (var db = new MyContext(ConnectionPath))
            {
                db.Database.CreateIfNotExists();
                db.Database.Initialize(true);
                db.SaveChanges();
            }

        }

        public List<T> GetDataFromDataBase<T>(string first, params string[] args)
        {
            using (var db = new MyContext(ConnectionPath))
            {
                //var c = new People();
                //c.Id = 10;
                //c.Name = "Дима";
                //db.Persons.Add(c);
                //db.SaveChanges();
                //var d = db.Persons.ToList();
                List<Reader> readers = db.Readers.ToList();
                //var cust1 = new Customer();
                //cust1.Id = 1;
                //cust1.First = "Dima";
                //cust1.Second = "Sokolov";
                //db.Customer.Add(cust1);
                //db.SaveChanges();
                return readers.Cast<T>().ToList();
            }

        }

        public MyContext getDB()
        {
            return new MyContext(ConnectionPath);
        }
    }
}