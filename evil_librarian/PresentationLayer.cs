using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using evil_librarian.Models;

namespace evil_librarian
{
    public class PresentationLayer
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        //Bear in mind the array! Ensure it's the correct Window you're trying to catch.

        public void UpdateDataGrid<T>(int DatagridNumber ,T data)
        {
            switch (DatagridNumber)
            {
                case 1:
                    Form.dataGridReaders.ItemsSource = data as IEnumerable;
                    break;
                case 2:
                    Form.dataGridBooks.ItemsSource = data as IEnumerable;
                    break;
                case 3:
                    Form.dataGridGenres.ItemsSource = data as IEnumerable;
                    break;
                case 4:
                    Form.dataGridExtradition.ItemsSource = data as IEnumerable;
                    break;
                case 5:
                    Form.dataGridPublishers.ItemsSource = data as IEnumerable;
                    break;
            }
            
            
        }

        public void DataGridReaders_Loaded(object sender, RoutedEventArgs e)
        {
            Form.dataGridReaders.Columns[0].Header = "id";
            Form.dataGridReaders.Columns[1].Header = "Фамилия";
            Form.dataGridReaders.Columns[2].Header = "Имя";
            Form.dataGridReaders.Columns[3].Header = "Отчество";
            Form.dataGridReaders.Columns[4].Header = "Дата рождения";
            Form.dataGridReaders.Columns[5].Header = "Паспорт";
            Form.dataGridReaders.Columns[6].Header = "Телефон";
        }

        public void DataGridBooks_Loaded(object sender, DataGridRowEventArgs dataGridRowEventArgs)
        {
            Form.dataGridBooks.Columns[0].Header = "id";
            Form.dataGridBooks.Columns[1].Header = "Автор";
            Form.dataGridBooks.Columns[2].Header = "Название";
            Form.dataGridBooks.Columns[3].Header = "Дата выпуска";
            Form.dataGridBooks.Columns[4].Header = "Количество";
            Form.dataGridBooks.Columns[5].Header = "Цена";
        }

        public void DataGridGenres_Loaded(object sender, DataGridRowEventArgs dataGridRowEventArgs)
        {
            Form.dataGridGenres.Columns[0].Header = "id";
            Form.dataGridGenres.Columns[1].Header = "Название жанра";
        }

        public void DataGridExtraditions_Loaded(object sender, DataGridRowEventArgs dataGridRowEventArgs)
        {
            Form.dataGridExtradition.Columns[0].Header = "id книги";
            Form.dataGridExtradition.Columns[1].Header = "id читателя";
            Form.dataGridExtradition.Columns[2].Header = "дата выдачи";
            Form.dataGridExtradition.Columns[3].Header = "дата возврата";
        }

        public void DataGridPublishers_Loaded(object sender, DataGridRowEventArgs dataGridRowEventArgs)
        {
            Form.dataGridPublishers.Columns[0].Header = "id";
            Form.dataGridPublishers.Columns[1].Header = "Название";
            Form.dataGridPublishers.Columns[2].Header = "Город";
        }

    }
}
