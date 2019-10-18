using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using evil_librarian.Models;

namespace evil_librarian
{
    class DataGridWorking
    {
        private MainWindow _mw;
        private DataAccessLayer dal;
        public DataGridWorking(MainWindow mainWindow)
        {
            _mw = mainWindow;
            dal = mainWindow.dal;
        }

        public void dataGridReaders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRecord = _mw.dataGridReaders.SelectedItem as Reader;

            if (currentRecord != null)
            {
                var recordFromDB = dal.getDB().Readers.FirstOrDefault(c => c.IdReader == currentRecord.IdReader);
                if (recordFromDB == null)
                {
                    dal.getDB().Readers.Add(currentRecord);


                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        //
                    }

                }
                else
                {
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Detached;
                    recordFromDB = currentRecord; //todo need refactoring it
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        if (recordFromDB.DateOfBirth.ToString() == "1/1/2018 12:00:00 AM")
                        {
                            throw new System.Data.Entity.Validation.DbEntityValidationException("");
                        }
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        System.Windows.MessageBox.Show("Есть незаполненные обязательные поля или дата рождения");
                    }
                    dal.getDB().Readers.Attach(recordFromDB);
                }

            }

        }
        //todo replace dataGrid* to sender as datagrid
        public void dataGridReaders_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //todo удаляет только по одной строчке :( И все последующие *PreviewKeyDown аналогично
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " Readers?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            var reader = row as Reader;
                            dal.getDB().Readers.Remove(reader);
                        }
                        dal.getDB().SaveChanges();
                        MessageBox.Show(grid.SelectedItems.Count + " Reader have being deleted!");
                    }
                }
            }
        }

        public void dataGridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRecord = _mw.dataGridBooks.SelectedItem as Book;

            if (currentRecord != null)
            {
                var recordFromDB = dal.getDB().Books.FirstOrDefault(c => c.IdBook == currentRecord.IdBook);
                if (recordFromDB == null)
                {
                    dal.getDB().Books.Add(currentRecord);


                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        //
                    }

                }
                else
                {
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Detached;
                    recordFromDB = currentRecord; //todo need refactoring it
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        if (recordFromDB.DateOfPrint.ToString() == "1/1/2018 12:00:00 AM")
                        {
                            throw new System.Data.Entity.Validation.DbEntityValidationException("");
                        }
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        System.Windows.MessageBox.Show("Есть незаполненные обязательные поля или дата рождения");
                    }
                    dal.getDB().Books.Attach(recordFromDB);
                }

            }
        }

        public void dataGridBooks_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " Books?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            var book = row as Book;
                            dal.getDB().Books.Remove(book);
                        }
                        dal.getDB().SaveChanges();
                        MessageBox.Show(grid.SelectedItems.Count + " Book have being deleted!");
                    }
                }
            }
        }

        public void dataGridGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRecord = _mw.dataGridGenres.SelectedItem as Genre;

            if (currentRecord != null)
            {
                var recordFromDB = dal.getDB().Genres.FirstOrDefault(c => c.IdGenre == currentRecord.IdGenre);
                if (recordFromDB == null)
                {
                    dal.getDB().Genres.Add(currentRecord);


                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        //
                    }

                }
                else
                {
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Detached;
                    recordFromDB = currentRecord; //todo need refactoring it
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        System.Windows.MessageBox.Show("Есть незаполненные обязательные поля или дата рождения");
                    }
                    dal.getDB().Genres.Attach(recordFromDB);
                }

            }
        }

        public void dataGridGenres_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " Genres?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            var genre = row as Genre;
                            dal.getDB().Genres.Remove(genre);
                        }
                        dal.getDB().SaveChanges();
                        MessageBox.Show(grid.SelectedItems.Count + " Genre have being deleted!");
                    }
                }
            }
        }

        public void dataGridExtraditions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRecord = _mw.dataGridExtradition.SelectedItem as Extradition;

            if (currentRecord != null)
            {
                var recordFromDB = dal.getDB().Extraditions.FirstOrDefault(c => c.IdBookEx == currentRecord.IdBookEx);
                if (recordFromDB == null)
                {
                    dal.getDB().Extraditions.Add(currentRecord);


                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        //
                    }

                }
                else
                {
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Detached;
                    recordFromDB = currentRecord; //todo need refactoring it
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        System.Windows.MessageBox.Show("Есть незаполненные обязательные поля или дата рождения");
                    }
                    dal.getDB().Extraditions.Attach(recordFromDB);
                }

            }
        }

        public void dataGridExtraditions_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " Extraditions?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            var extrd = row as Extradition;
                            dal.getDB().Extraditions.Remove(extrd);
                        }
                        dal.getDB().SaveChanges();
                        MessageBox.Show(grid.SelectedItems.Count + " Extradition have being deleted!");
                    }
                }
            }
        }

        public void dataGridPublishers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRecord = _mw.dataGridPublishers.SelectedItem as Creator;

            if (currentRecord != null)
            {
                var recordFromDB = dal.getDB().Publishers.FirstOrDefault(c => c.IdCreator == currentRecord.IdCreator);
                if (recordFromDB == null)
                {
                    dal.getDB().Publishers.Add(currentRecord);


                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        //
                    }

                }
                else
                {
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Detached;
                    recordFromDB = currentRecord; //todo need refactoring it
                    dal.getDB().Entry(recordFromDB).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        dal.getDB().SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                    {
                        System.Windows.MessageBox.Show("Есть незаполненные обязательные поля или дата рождения");
                    }
                    dal.getDB().Publishers.Attach(recordFromDB);
                }

            }
        }

        public void dataGridPublishers_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " Publishers?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            var publisher = row as Creator;
                            dal.getDB().Publishers.Remove(publisher);
                        }
                        dal.getDB().SaveChanges();
                        MessageBox.Show(grid.SelectedItems.Count + " Publisher have being deleted!");
                    }
                }
            }
        }
        public void ResultsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
            {
                DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
                if (dataGridTextColumn != null)
                {
                    dataGridTextColumn.Binding.StringFormat = "{0:d}";
                }
            }
        }
    }
}
