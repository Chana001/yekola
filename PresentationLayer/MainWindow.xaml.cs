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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User _user;
        
        public MainWindow()
        {
            pg4SignIn.TriggerEventFromSignIn += new EventHandler(pageHome_SomethingHappened);
            pg5signUp.TriggerEvent += new EventHandler(pageHome_SomethingHappened2);
            InitializeComponent();
            frPages.NavigationService.Navigate( new pg1GreetingsPage() );
     
        }

        private void msdResetUsernameAndPassword(object sender, MouseButtonEventArgs e)
        {
            //Reset Password
            var resetPass = new pg7ResetUserAndPassword();
            frPages.NavigationService.Navigate(resetPass);
        }

        private void msdContactUs(object sender, MouseButtonEventArgs e)
        {
            //About Us Page
            var contactUs = new pg2ContactUs();
            frPages.NavigationService.Navigate(contactUs);

        }

        private void msdAboutUs(object sender, MouseButtonEventArgs e)
        {
            //About Us Page
            var aboutUs = new pg3AboutUs();
            frPages.NavigationService.Navigate(aboutUs);

        }

        private void msdSignIn(object sender, MouseButtonEventArgs e)
        {
            //Sign In
            if (txtSignIn.Text.Equals(" Sign In "))
            {
                var signIn = new pg4SignIn();
                frPages.NavigationService.Navigate(signIn);
            }
            else
            {
                _user = null;
                txtSignIn.Text = " Sign In ";
                txtSignUp.Visibility = Visibility.Visible;
                txtNameTag.Text = "Not Logged In";
                txtSignIn.Foreground = new SolidColorBrush(Colors.Black);
                frPages.NavigationService.Navigate(new pg1GreetingsPage());
            }
            
        }

        private void msdSignUp(object sender, MouseButtonEventArgs e)
        {
            //Sign Up
            //Sign In
            var signUp = new pg5signUp();
            frPages.NavigationService.Navigate(signUp);
        }

        private void msdHome(object sender, MouseButtonEventArgs e)
        {
            //Go Home
            var homePage = new pg1GreetingsPage();
            frPages.NavigationService.Navigate(homePage);

        }

        private void imgYcLogo(object sender, MouseButtonEventArgs e)
        {
            //Go Home
            var homePage = new pg1GreetingsPage();
            frPages.NavigationService.Navigate(homePage);
        }

        private void btnAdmin(object sender, RoutedEventArgs e)
        {
            //Go Home
            var admin = new pg8AddQuestions(_user); //temporary
             frPages.NavigationService.Navigate(admin);
        }

        public void setUser(User user)
        {
            _user = user;
        }


        void pageHome_SomethingHappened(object sender, EventArgs e)
        {
            
            txtSignIn.Text = "Log Out";
            txtSignUp.Visibility = Visibility.Hidden;
            txtSignIn.Foreground = new SolidColorBrush(Colors.Red);
            

            var a = (pg4SignIn)frPages.Content;
            _user = a.getUser();
            txtNameTag.Text += " " + _user.FirstName + " " + _user.LastName;

            foreach (var role in _user.UserRoles)
            {
                switch (role.Id)
                {
                    case "Admin":
                        btnAdministrator.Visibility = Visibility.Visible;
                        break;
                    case "Player":
                        btnAdministrator.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }

            }
        }

        void pageHome_SomethingHappened2(object sender, EventArgs e)
        {

            txtSignIn.Text = "Log Out";
            txtSignUp.Visibility = Visibility.Hidden;
            txtSignIn.Foreground = new SolidColorBrush(Colors.Red);

            var b = (pg5signUp)frPages.Content;
            _user = b.getUser();
            txtNameTag.Text += " " + _user.FirstName + " " + _user.LastName;

            foreach (var role in _user.UserRoles)
            {
                switch (role.Id)
                {
                    case "Admin":
                        btnAdministrator.Visibility = Visibility.Visible;
                        break;
                    case "Player":
                        btnAdministrator.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }

            }
        }
        
    }
}
