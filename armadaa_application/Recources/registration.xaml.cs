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

                    connection.CreateTable<User>();
                    var user = connection.Table<User>().FirstOrDefault(u => u.Username == userName);

                    //Ha van ilyen felhasználó
                    
                        if (passwordHash == passwordAgainHash) { 
                        
                        var UserRepo = new GenericRepository<User>(App.databasePath);
                        var registreredUser = new User(passwordHash, userName, email);
                        UserRepo.insert(registreredUser);
                         Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Close();
                        }
                    
                    else
                    {
                        MessageBox.Show("Regisztráció Sikeretelen");
                    }
                }
            }

        }

        private void toLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
