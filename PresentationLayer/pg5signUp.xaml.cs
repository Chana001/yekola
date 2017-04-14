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
    /// Interaction logic for pg5signUp.xaml
    /// </summary>
    public partial class pg5signUp : Page
    {
        User _user;

        public pg5signUp()
        {
            InitializeComponent();
        }

        private void btnSignUp(object sender, RoutedEventArgs e)
        {
            if (1 == ValidateInput())
                return;


            //Create Employee
            var userManager = new UserManager();

            var user = new User();

            //Username
            user.UserName = txtUsername.Text;

            //First and Last Name
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;

            //Email
            user.Email = txtEmail.Text;

            //Passwords
            string password1 = txtPassword.Text;
            string password2 = txtConfirmPassword.Text;



            //Set UserRole
            user.UserRolesID = "Player";

            //Check for Correctly Input password
            if ( checkPassword(password1, password2) )
            {
                user.PasswordHash = password2;
                try
                {
                    if (userManager.CreateUser(user))
                    {
                        //Get user with Id
                        var userManager2 = new UserManager();
                        _user = userManager2.RetrieveUserByUsername(user.UserName);
                        _user.UserRoles = userManager2.retrieveRoles(user.Id);
                        this.UpdateParentForm(e);

                        var welcomePage = new pg6WelcomePage(_user);
                        this.NavigationService.Navigate(welcomePage);
                    } 
                }
                catch (Exception)
                {
                    MessageBox.Show("Username already exists in system");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Passwords do not match, I don't like that!");
                return;
            }


            //= txtConfirmPassword.Text;           

        }

        private int ValidateInput()
        {
            int result = 0;

            if ( txtUsername.Text == "" || txtUsername.Text == "Username" )
            {
                result = 1;
                MessageBox.Show("Kindly enter Username");
                return result;
            }

            if ( txtFirstName.Text == "" || txtFirstName.Text =="First Name")
            {
                result = 1;
                MessageBox.Show("KIndly enter first name");
                return result;
            }

            if ( txtLastName.Text == "" || txtLastName.Text == "Last Name")
            {
                result = 1;
                MessageBox.Show("Kindly enter last name");
                return result;
            }

            if ( txtEmail.Text == "" || txtEmail.Text == "Email")
            {
                result = 1;
                MessageBox.Show("Kindly enter eamil");
                return result;
            }

            return result;
        }

        private bool checkPassword(string a1, string a2)
        {
            bool result = false;

            if (a1 == a2)
            {
                result = true;
            }

            return result;
        }

        public static event EventHandler TriggerEvent;

        private void UpdateParentForm(EventArgs e)
        {
            if (_user != null)
            {
                TriggerEvent(this, e);
            }
        }

        public User getUser()
        {
            return _user;
        }
    }
}
