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
    /// Interaction logic for pg6WelcomePage.xaml
    /// </summary>
    public partial class pg6WelcomePage : Page
    {
        User _user;


        public pg6WelcomePage(User user)
        {
            _user = user;
            InitializeComponent();
            SetupWindow();
        }

        private void SetupWindow()
        {
            txtNameTag.Text += _user.FirstName;
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            //Go Home
            var greetingsPage = new pg1GreetingsPage();
            this.NavigationService.Navigate(greetingsPage);
        }

        private void btnStartQuiz(object sender, RoutedEventArgs e)
        {
            //Go to quiz
            var takeQuiz = new pg9TakeQuiz(_user);
            this.NavigationService.Navigate(takeQuiz);
        }
    }
}
