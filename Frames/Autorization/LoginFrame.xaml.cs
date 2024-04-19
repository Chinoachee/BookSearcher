using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BooksSearcher.Frames.Autorization {
    public partial class LoginFrame : Page {
        public LoginFrame() {
            InitializeComponent();
        }

        private void autorizationButton_Click(object sender,RoutedEventArgs e) {
            Model.Usermodel.UserBase users = new Model.Usermodel.UserBase();
            Model.Usermodel.User newUser = new Model.Usermodel.User(loginTextBox.Text,passwordTextBox.Password);
            if(!users.Autorization(newUser)) {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            NavigationService.Navigate(new MainFrame(newUser));
        }

        private void registrationButton_Click(object sender,RoutedEventArgs e) {
            NavigationService.Navigate(new RegistrationFrame());
        }

    }
}
