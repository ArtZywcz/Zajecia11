using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>()
        {
            new User("admin", "admin"),
        };
        public event EventHandler<LoginFailureEventArgs> LoginFailed;
        public event EventHandler<EventArgs> LoginSucces;
        public MainWindow()
        {

            InitializeComponent();
            new LoginControl();
            LoginFailed += CustomLoginControl.OnLoginFailure;
            LoginSucces += CustomLoginControl.OnLoginSucces;
        }
        public void CostomLoginControl_LoginAttempt(object sender, LoginEventArgs e)
        {
            var user = users.Where(x => x.CheckLogin(e.Login, e.Password.ToString())).SingleOrDefault();

            if (user == null)
            {
                LoginFailed?.Invoke(this, new LoginFailureEventArgs()
                {
                    Errors = new List<LoginFailureEventArgs.LoginError>()
                    {
                        new LoginFailureEventArgs.LoginError()
                        {
                            Field = LoginFields.All,
                            ErrorMessage = "Zły login lub hasło"
                        }
                    }
                });
            }
            else
            {
                LoginSucces?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

    }
}
