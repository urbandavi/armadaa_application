using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armadaa_application.Model
{
    class User
    {
        
        public int Id { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Felhasznalonev { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
