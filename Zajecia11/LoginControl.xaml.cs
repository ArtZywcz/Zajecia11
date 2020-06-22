using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zajecia11
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public event EventHandler<LoginEventArgs> LoginAtempt;
        public string Login { get; set; }
        public string Password { get; set; }
        public LoginControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Children.Clear();
            Login = TextLogin.Text;
            Password = PasswordBox.Password;
            LoginAtempt?.Invoke(this, new LoginEventArgs(Login, Password));
        }
        public void OnLoginSucces(object sender, EventArgs e)
        {
            MessageBox.Show("Logowanie zakończono pomyślnie!", "Login", MessageBoxButton.OK);
            
        }
        public void OnLoginFailure(object sender, LoginFailureEventArgs e)
        {
            foreach (var item in e.Errors)
            {
                ErrorStackPanel.Children.Add(
                    new Label()
                    {
                        Content = $"[{item.Field}] {item.ErrorMessage}",
                        Foreground = new SolidColorBrush(Colors.Red)
                    });
            }
            Login = string.Empty;
            PasswordBox.Clear();

        }

    }
}