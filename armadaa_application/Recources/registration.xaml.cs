using armadaa_application.Model;
using eKreta.Services;
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

namespace armadaa_application.Recources
{
    /// <summary>
    /// Interaction logic for registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = usernameTbx.Text;
            string email = emailTbx.Text;

            string passwordHash = PasswordHelper.HashPassword(passwordTbx.Password);
            string passwordAgainHash = PasswordHelper.HashPassword(passwordAgainTbx.Password);

            if (!string.IsNullOrEmpty(usernameTbx.Text) || !string.IsNullOrEmpty(passwordAgainTbx.Password)||!string.IsNullOrEmpty(passwordTbx.Password)||!string.IsNullOrEmpty(emailTbx.Text))
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    var user = connection.Table<User>().FirstOrDefault(u => u.Username == userName);

                    //Ha van ilyen felhasználó
                    if (user != null)
                    {
                        var UserRepo = new GenericRepository<User>(App.databasePath);
                        var registreredUser = new User(userName, email, passwordHash);
                    }
                    else
                    {
                        MessageBox.Show("Belépés megtagadva! ");
                    }
                }
            }

        }

        private void toLoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
