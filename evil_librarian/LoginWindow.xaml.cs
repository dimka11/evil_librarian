using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

namespace evil_librarian
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow _mw;
        public LoginWindow(MainWindow mw)
        {
            InitializeComponent();
            _mw = mw;
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = TextBoxUser.Text;
            var password = TextBoxPassword.Text;
            //todo query to DB
            var dal = _mw.dal;
            var user_entity = dal.getDB().Login.Find(user);
            if (user_entity != null && user_entity.Password == password)
            {
                _mw.Visibility = Visibility.Visible;
                Close();
            }
            else
            {
                MessageBox.Show("Fuck you !");
            }

        }
    }
}
