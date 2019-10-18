using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace evil_librarian
{
    class PresentationLayer
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        //Bear in mind the array! Ensure it's the correct Window you're trying to catch.

        public void UpdateDataGrid<T>(T data)
        {
            Form.dataGridReaders.ItemsSource = data as IEnumerable;
        }
    }
}
