using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armadaa_application.Model
{
    class User
    {
        public User(string vezeteknev, string keresztnev, string felhasznalonev, string password, string email)
        {
            Vezeteknev = vezeteknev;
            Keresztnev = keresztnev;
            Felhasznalonev = felhasznalonev;
            Password = password;
            Email = email;
        }
        public User()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Felhasznalonev { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
