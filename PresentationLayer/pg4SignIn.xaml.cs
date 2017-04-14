using BusinessLogic;
using DataObjects;
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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for pg4SignIn.xaml
    /// </summary>
    public partial class pg4SignIn : Page
    {
        /// <summary>
        /// User object
        /// </summary>
        User _user;

        public pg4SignIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <returns></returns>
        public User getUser()
        {
            return _user;
        }

        public static event EventHandler TriggerEventFromSignIn;
        private void UpdateParentFromSignIn(EventArgs e)
        {
            if (_user != null)
            {
                TriggerEventFromSignIn(this, e);
            }
        }


        private void btnSignIn(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var usrMgr = new UserManager();


            if (_user == null)
            {
                try
                {
                    _user = usrMgr.AuthenticateUser(username, password);
                    MessageBox.Show("Welcome back, " + _user.FirstName + ".");
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.IsEnabled = false;
                    txtPassword.IsEnabled = false;
                    this.UpdateParentFromSignIn(e);

                    //Window parentWindow = Window.GetWindow(this);
                    

                    //Sign In

                    if ( _user.UserRoles[0].Id == "Player" )
                    {
                        var takeQuiz = new pg9TakeQuiz(_user);
                        this.NavigationService.Navigate(takeQuiz);
                    }
                    else
                    {
                        var addQuestions = new pg8AddQuestions(_user);
                        this.NavigationService.Navigate(addQuestions);
                    }
                   

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Authentication Failed.");
                }
            }
            else
            {
                _user = null;
                txtUsername.IsEnabled = true;
                txtPassword.IsEnabled = true;
                txtUsername.Focus();

            }


        }
    }
}
