using System.IO;
using System.Text.Json;

namespace BooksSearcher.Model.Usermodel {
    internal class UserBase {
        List<User> users;
        private void LoadUsers(string filePath = "users.json") {
            if(!File.Exists(filePath)) return;
            string jsonValue = File.ReadAllText(filePath);
            users = JsonSerializer.Deserialize<List<User>>(jsonValue);
        }
        private void SaveUsers(string filePath = "users.json") {
            string jsonValue = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath,jsonValue);
        }
        public UserBase() {
            users = new List<User>();
            LoadUsers();
        }
        public bool Autorization(User user) {
            foreach(User oldUser in users) { 
                if(oldUser.Login == user.Login) {
                    if(oldUser.Password == user.Password) {
                        user = oldUser;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Registation(User user) {
            foreach(User oldUser in users) {
                if(oldUser.Login == user.Login) return false;
            }
            users.Add(user);
            SaveUsers();
            return true;
        }
    }
}
