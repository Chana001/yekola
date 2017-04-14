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
    /// Interaction logic for pg1GreetingsPage.xaml
    /// </summary>
    public partial class pg1GreetingsPage : Page
    {
        public pg1GreetingsPage()
        {
            InitializeComponent();
        }

        private void btnGetStarted(object sender, RoutedEventArgs e)
        {
            var signUP = new pg5signUp();
            this.NavigationService.Navigate(signUP);
        }

        private void actlblHasAccount(object sender, MouseButtonEventArgs e)
        {
            var signIN = new pg4SignIn();
            this.NavigationService.Navigate(signIN);
        }
    }
}
