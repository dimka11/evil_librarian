using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using evil_librarian.Models;

namespace evil_librarian
{
    public class DataAccessLayer
    {

        private string ConnectionPath { get; }

        private MyContext _myContext;

        public DataAccessLayer(string connectionPath)
        {
            ConnectionPath = connectionPath;
            _myContext = new MyContext(ConnectionPath);
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

        public List<T> GetDataFromDataBase<T>(string entity, params string[] args)
        {
            using (var db = new MyContext(ConnectionPath))
            {
                switch (entity)
                {
                    case "readers":
                        List<Reader> readers = db.Readers.ToList();
                        return readers.Cast<T>().ToList();

                    case "books":
                        List<Book> books = db.Books.ToList();
                        return books.Cast<T>().ToList();

                    case "creators":
                        List<Creator> publishers = db.Publishers.ToList();
                        return publishers.Cast<T>().ToList();

                    case "genres":
                        List<Genre> genres = db.Genres.ToList();
                        return genres.Cast<T>().ToList();

                    case "extraditions":
                        List<Extradition> extraditions = db.Extraditions.ToList();
                        return extraditions.Cast<T>().ToList();

                    default:
                        new InvalidOperationException("no entity");
                        break;
                }

            }

            throw new InvalidOperationException("no entity");
        }

        public MyContext getDB()
        {
            return _myContext;
        }

    }


}