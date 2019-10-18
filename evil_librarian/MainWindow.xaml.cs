using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
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
using evil_librarian.Models;
using SQLite.CodeFirst;

namespace evil_librarian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent(); // Init main
            var dal = new DataAccessLayer(@"..\..\evil.sqlite");
            //dal.CreateDataBase(); // doesn't work
            var entities_readers = dal.GetDataFromDataBase<Reader>("forTestOnly");
            var present = new PresentationLayer();
            present.UpdateDataGrid(entities_readers);
        }

    }
}
