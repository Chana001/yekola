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
    /// Interaction logic for pg9TakeQuiz.xaml
    /// </summary>
    public partial class pg9TakeQuiz : Page
    {
        User _user;

        List<PlayerLevelCategory> _lstPlayerLevelCategories;

        public pg9TakeQuiz(User user)
        {
            _user = user;
            InitializeComponent();
            loadPlayerData();
            
        }

        public pg9TakeQuiz()
        {
            InitializeComponent();

        }

        private void btnGoToQuiz(object sender, RoutedEventArgs e)
        {
            if ( (PlayerLevelCategory)gameSummaryList.SelectedItem != null)
            {
                //Get Selected Item
                var selectedQuiz = (PlayerLevelCategory)gameSummaryList.SelectedItem;


                //Set current user
                selectedQuiz.UserID = _user.Id;


                //Check if player has privileges
                if (1 == CheckUserGamePrivilege(selectedQuiz))
                    return;   

                //Go to main quiz
                var mainQuiz = new pg10mainQuiz(selectedQuiz);
                this.NavigationService.Navigate(mainQuiz);

            }
            else
            {
                MessageBox.Show("Select an option");
            }  
        }

        private int CheckUserGamePrivilege(PlayerLevelCategory selectedQuiz)
        {
            int result = 0;

            if ( selectedQuiz.LevelId != 3000)
            {
                if (_lstPlayerLevelCategories[selectedQuiz.LevelId - (3000 + 1)].Unlocked == false)
                {
                    MessageBox.Show("Complete preceding level first!.");
                    result = 1;
                }
            }

            return result;
        }

        private void loadPlayerData()
        {

            var quizManager = new QuizManager();

            _lstPlayerLevelCategories = quizManager.getPlayerGameSummary( _user.Id );

            var playerSummary = _lstPlayerLevelCategories;

            int count = 0;
            foreach (var k in playerSummary )
            {
                if ( playerSummary[count].Unlocked == true )
                {
                    playerSummary[count].UnlockedText = "Complete";
                }
                else
                {
                    playerSummary[count].UnlockedText = "Incomplete";
                }
                count++;
                
            }


            gameSummaryList.ItemsSource = playerSummary;

        }
    }
}
