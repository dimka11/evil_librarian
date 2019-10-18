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
            var user = TextBoxUser;
            var password = TextBoxPassword;
            //todo query to DB
        }
    }
}
