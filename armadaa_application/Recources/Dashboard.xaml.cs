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
using armadaa_application.Model;
using eKreta.Models;
using SQLite;

namespace armadaa_application.Recources
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Create_Product_Click(object sender, RoutedEventArgs e)
        {
            int termekar = Convert.ToInt32(termekArTbx.Text); 
            string termeknev = termek_nev_tbx.Text;

            if(!string.IsNullOrEmpty(termek_nev_tbx.Text) && !string.IsNullOrEmpty(termekArTbx.Text))
            {
                Products product = new Products(termeknev, termekar);

                using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Products>();
                    connection.Insert(product);
                    MessageBox.Show($"A {termeknev} termék sikeresen hozzá lett adva az adatbázishoz");
                }
            }
        }

        private void getAll_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection connection=new SQLiteConnection(App.databasePath)) 
            {
                var ProductsRepo = new GenericRepository<Products>(App.databasePath);
                var GetAllProducts = ProductsRepo.GetAll();
                productsLBX.Items.Add("Termék neve || Ár");
                foreach (Products Product in GetAllProducts) {
                      productsLBX.Items.Add(Product.Termeknev+"     "+Product.TermekAr);
                }
            }
        }
    }
}
