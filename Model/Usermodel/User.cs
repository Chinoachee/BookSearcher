using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSearcher.Model.Usermodel
{
    public class User
    {
        private string? login;
        public string? Login
        {
            get { return login; }
            set { login = value; }
        }

        private string? password;
        public string? Password
        {
            get { return password; }
            set { password = value; }
        }

        public List<Book> FavouriteBook { get; set; }

        public User() {
            FavouriteBook = new List<Book>();
        }
        public User(string login, string password) {
            this.login = login; 
            this.password = password;
            FavouriteBook = new List<Book>();
        }
    }
}
