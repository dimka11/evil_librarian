using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        public DataAccessLayer dal = new DataAccessLayer(@"..\..\evil.sqlite");
        public MainWindow()
        {
            InitializeComponent(); // Init main

            //todo login form showing code commented due development process reason
            var loginWindow = new LoginWindow(this);
            //loginWindow.Show();
            //Visibility = Visibility.Hidden;

            //dal.CreateDataBase(); // doesn't work
            var entities_readers = dal.GetDataFromDataBase<Reader>("readers");
            var entities_books = dal.GetDataFromDataBase<Book>("books");
            var entities_publishers = dal.GetDataFromDataBase<Creator>("creators");
            var entities_genres = dal.GetDataFromDataBase<Genre>("genres");
            var entities_extraditions = dal.GetDataFromDataBase<Extradition>("extraditions");

            var present = new PresentationLayer();
            present.UpdateDataGrid(1, entities_readers);
            present.UpdateDataGrid(2, entities_books);
            present.UpdateDataGrid(3, entities_genres);
            present.UpdateDataGrid(4, entities_extraditions);
            present.UpdateDataGrid(5, entities_publishers);

            //Events:
            dataGridReaders.Loaded += present.DataGridReaders_Loaded;
            dataGridBooks.LoadingRow += present.DataGridBooks_Loaded;
            dataGridGenres.LoadingRow += present.DataGridGenres_Loaded;
            dataGridExtradition.LoadingRow += present.DataGridExtraditions_Loaded;
            dataGridPublishers.LoadingRow += present.DataGridPublishers_Loaded;

            var dataGridWorking = new DataGridWorking(this);

            dataGridReaders.SelectionChanged += dataGridWorking.dataGridReaders_SelectionChanged;
            dataGridReaders.PreviewKeyDown += dataGridWorking.dataGridReaders_PreviewKeyDown;

            dataGridBooks.SelectionChanged += dataGridWorking.dataGridBooks_SelectionChanged;
            dataGridBooks.PreviewKeyDown += dataGridWorking.dataGridBooks_PreviewKeyDown;

            dataGridGenres.SelectionChanged += dataGridWorking.dataGridGenres_SelectionChanged;
            dataGridGenres.PreviewKeyDown += dataGridWorking.dataGridGenres_PreviewKeyDown;

            dataGridExtradition.SelectionChanged += dataGridWorking.dataGridExtraditions_SelectionChanged;
            dataGridExtradition.PreviewKeyDown += dataGridWorking.dataGridExtraditions_PreviewKeyDown;

            dataGridPublishers.SelectionChanged += dataGridWorking.dataGridPublishers_SelectionChanged;
            dataGridPublishers.PreviewKeyDown += dataGridWorking.dataGridPublishers_PreviewKeyDown;

            //on autogeneratingcolumn... //todo дата редактируется через раз
            dataGridReaders.AutoGeneratingColumn += dataGridWorking.ResultsDataGrid_AutoGeneratingColumn;
            dataGridBooks.AutoGeneratingColumn += dataGridWorking.ResultsDataGrid_AutoGeneratingColumn;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            new EditingWindow().ShowDialog();

        }
    }

}