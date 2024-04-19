using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BooksSearcher.Frames.Autorization {
    public partial class RegistrationFrame : Page {
        public RegistrationFrame() {
            InitializeComponent();
        }

        private void backToLogin_Click(object sender,RoutedEventArgs e) {
            NavigationService.Navigate(new LoginFrame());
        }

        private void registationButton_Click(object sender,RoutedEventArgs e) {
            Model.Usermodel.UserBase users = new Model.Usermodel.UserBase();
            Model.Usermodel.User user = new Model.Usermodel.User(loginTextBox.Text,passwordTextBox.Password);
            if(!users.Registation(user)) return;
            NavigationService.Navigate(new MainFrame(user));
        }
    }
}
