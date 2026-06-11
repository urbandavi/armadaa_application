using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace armadaa_application.Model
{
    internal class Products
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Termeknev { get; set; }
        public int TermekAr { get; set; }

        public string HozzaadoFelhasznalo { get; set; }
       


        public Products()
        {
        }

        public Products(string termeknev, int termekar)
        {
            Termeknev = termeknev;
            TermekAr= termekar;
            


        }
    }
}
