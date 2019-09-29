using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite.CodeFirst;

namespace evil_librarian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    [Table("People")]
    class People
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Context:
    class MyContext : DbContext
    {

        public DbSet<People> Persons { get; set; }

        public MyContext(string filename) : base(new SQLiteConnection()
        {
            ConnectionString =
                new SQLiteConnectionStringBuilder()
                        {DataSource = filename, ForeignKeys = true}
                    .ConnectionString
        }, true)
        {
            
        }
    }

    public partial class MainWindow : Window
    {
        string _connectionPath = @"..\..\evil.sqlite";
        public MainWindow()
        {
            InitializeComponent();
           // DataAccessLayer();
            Generate();

        }

        //In the DAL:
        public void DataAccessLayer()
        {
            

            using (var db = new MyContext(_connectionPath))
            {
                db.Database.CreateIfNotExists();
                db.Database.Initialize(false);
                db.SaveChanges();
            }

        }
        void Generate()
        {
            using (var db = new MyContext(_connectionPath))
            {
                var c = new People();
                //c.Id = 10;
                c.Name = "Дима";
                db.Persons.Add(c);
                db.SaveChanges();
                var d = db.Persons.ToList();
                var z = 0;
            }
        }
    }
}
