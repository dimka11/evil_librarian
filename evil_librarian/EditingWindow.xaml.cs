using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using evil_librarian.Models;

namespace evil_librarian
{
    /// <summary>
    /// Interaction logic for EditingWindow.xaml
    /// </summary>
    public partial class EditingWindow : Window
    {
        private int record;
        private DataAccessLayer dal;

        public EditingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //todo save editing to db
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            record = 1;
            dal = new DataAccessLayer(@"..\..\evil.sqlite"); //todo hardcoded db
            // load data from DB
            var recordFromDb = dal.getDB().Readers.FirstOrDefault(c => c.IdReader == record);
            UpdateTextBox(recordFromDb);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (record > 1)
            {
                record--;
            }
            var recordFromDb = dal.getDB().Readers.FirstOrDefault(c => c.IdReader == record);
            UpdateTextBox(recordFromDb);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (record <= 20) //too hardcoded record count
            {
                record++;
            }
            var recordFromDb = dal.getDB().Readers.FirstOrDefault(c => c.IdReader == record);
            UpdateTextBox(recordFromDb);
        }

        private void UpdateTextBox(Reader r)
        {
            TextBoxId.Text = r.IdReader.ToString();
            TextBoxSecond.Text = r.Surname;
            TextBoxFirst.Text = r.Name;
            TextBoxMiddle.Text = r.Patronimic;
            TextBoxBirthDate.Text = r.DateOfBirth.ToShortDateString();
            TextBoxPassport.Text = r.Passport;
            TextBoxPassport.Text = r.Passport;
        }

        private void TextBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            //todo save changes to entity
        }
    }
}
