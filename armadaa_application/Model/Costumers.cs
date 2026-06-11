using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armadaa_application.Model
{
    public class Costumer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string VasarloTeljesNeve { get; set; }
        public int VasarloSzuletesiEve { get; set; }
        public int VasarloBankszamlaSzama { get; set; }


        public Costumer()
        {
        }

        public Costumer(string vasarloTeljesNeve, int vasarloSzuletesiEve, int vasarloBankszamlaSzama)
        {
            VasarloTeljesNeve = vasarloTeljesNeve;
            VasarloSzuletesiEve = vasarloSzuletesiEve;
            VasarloBankszamlaSzama = vasarloBankszamlaSzama;
        }
    }
}
