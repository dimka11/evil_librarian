using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace evil_librarian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class MyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new MyContext())
            {
                var person = new Person() { Name = "John" };
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var label = (Label)sender;
            //label.Content = "Hello";

            using (var db = new MyContext())
            {
                var c = db.Persons.ToList();
                label.Content = "Hello";
            }
        }
    }
}
