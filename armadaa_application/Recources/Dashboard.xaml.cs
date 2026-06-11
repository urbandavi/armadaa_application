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
                connection.CreateTable<Products>();
                var GetAllProducts = ProductsRepo.GetAll();
                productsLBX.Items.Add("Termék neve || Ár");
                foreach (Products Product in GetAllProducts) {
                      productsLBX.Items.Add(Product.Termeknev+"     "+Product.TermekAr);
                }
            }
        }

        private void getAllVasarlo_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                var CostumerRepo = new GenericRepository<Costumer>(App.databasePath);
                connection.CreateTable<Costumer>();
                var GetAllProducts = CostumerRepo.GetAll();
                vasarlok.Items.Add("Vasarlo neve || Ár");
                foreach (Costumer costumer in GetAllProducts)
                {
                    vasarlok.Items.Add(costumer.VasarloTeljesNeve + "     " + costumer.VasarloSzuletesiEve);
                }
            }
        }

        private void registerVasarlo_Click(object sender, RoutedEventArgs e)
        {
            string costNeam = vasarloNev.Text;
            int szuletesiev = Convert.ToInt32(vasarloSzulEv.Text);
            int bankszamlaszam = Convert.ToInt32(Bankszamlaszama.Text);

            if (!string.IsNullOrEmpty(vasarloNev.Text) && !string.IsNullOrEmpty(vasarloSzulEv.Text) && !string.IsNullOrEmpty(Bankszamlaszama.Text))
            {
                Costumer costumer = new Costumer(costNeam,szuletesiev,bankszamlaszam);

                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Costumer>();
                    connection.Insert(costumer);
                    MessageBox.Show($"A {costNeam} vásárló sikeresen hozzá lett adva az adatbázishoz");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
