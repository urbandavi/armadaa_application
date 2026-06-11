using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace armadaa_application.Model
{
    public class Felhasznalo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string Emailcim { get; set; }
        public string Jelszo { get; set; }
        

        public Felhasznalo()
        {
        }

        public Felhasznalo(string felhasznaloNev, string emailcim, string jelszo, int szerepkor)
        {
            FelhasznaloNev = felhasznaloNev;
            Emailcim = emailcim;
            Jelszo = jelszo;
        }
    }
}
