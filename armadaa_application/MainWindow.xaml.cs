using armadaa_application.Recources;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace armadaa_application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = loginUserText.Text;
            string passwordHash = PasswordHelper.HashPassword(loginPasswordText.Password);

            if (!string.IsNullOrEmpty(loginUserText.Text) || !string.IsNullOrEmpty(loginPasswordText.Password))
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    var user = connection.Table<Felhasznalo>().FirstOrDefault(u => u.FelhasznaloNev == userName);

                    //Ha van ilyen felhasználó
                    if (user != null)
                    {
                        // jelszóellenőrzés
                        if (user.Jelszo == passwordHash)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Belépés megtagadva! ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belépés megtagadva! ");
                    }
                }
            }
        }

        private void toRegButton_Click(object sender, RoutedEventArgs e)
        {
            var regpage = new registration();
            regpage.ShowDialog();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}