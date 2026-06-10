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
        public User(string username, string password, string email)
        {
           
          
            Password = password;
            Username = username;
            Email = email;
        }
        public User()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
