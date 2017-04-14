using BusinessLogic;
using DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for pg10mainQuiz.xaml
    /// </summary>
    public partial class pg10mainQuiz : Page
    {
        PlayerLevelCategory _playerSummary;

        List<QuestionViewModel> _lstQuestionViewModel = new List<QuestionViewModel>();

        bool _triggerCheckEvent = false;

        public pg10mainQuiz(PlayerLevelCategory playerSummary)
        {
            _playerSummary = playerSummary;
            _triggerCheckEvent = false;
            InitializeComponent();
            initialWindowSetup();
            loadGameData();
            _triggerCheckEvent = true;
        }

        public pg10mainQuiz()
        {
            InitializeComponent();
        }

        public void initialWindowSetup()
        {
            txtlevel.Text = _playerSummary.Level;
            txtCategory.Text = _playerSummary.Category;
        }

        public void loadGameData()
        {
            var quizManager = new QuizManager();

            string currentUser = "Player";

            _lstQuestionViewModel = quizManager.getGameData(_playerSummary.LevelId, currentUser);

            if ( _lstQuestionViewModel.Count == 0 )
            {
                MessageBox.Show("Level III Under Construction");
            }

            gameBodyList.ItemsSource = _lstQuestionViewModel; 

        }

        public void RefreshDataGridView()
        {
            gameBodyList.ItemsSource = _lstQuestionViewModel;
        }

        private void btnSubmit_Button_Click(object sender, RoutedEventArgs e)
        {
 
            var quizManager = new QuizManager();

            //Grade 
            decimal grade = quizManager.GradePlayer(_lstQuestionViewModel, _playerSummary);

            MessageBox.Show("Your score is " + grade.ToString("#.##") + "%");

            //Navigate back to Summary Page
            var user = new User();
            user.Id = _playerSummary.UserID;
            pg9TakeQuiz pg9TakeQuiz = new pg9TakeQuiz(user);
            this.NavigationService.Navigate(pg9TakeQuiz);
        }



        private void op1_Checked(object sender, RoutedEventArgs e)
        {
            if ( _triggerCheckEvent )
            {

                //Get Selected Row
                int a = gameBodyList.SelectedIndex;

                //Mutate _lstQuestionViewModel
                _lstQuestionViewModel[a].chkOption1 = true;
                _lstQuestionViewModel[a].chkOption2 = false;
                _lstQuestionViewModel[a].chkOption3 = false;
                _lstQuestionViewModel[a].chkOption4 = false;

                //Refresh View
                RefreshDataGridView();
            }   

        }

        private void op1_Unchecked(object sender, RoutedEventArgs e)
        {
            //Get Selected Row
            int a = gameBodyList.SelectedIndex;

            //Mutate _lstQuestionViewModel
            _lstQuestionViewModel[a].chkOption1 = false;

            //Refresh View
            RefreshDataGridView(); 

        }

        private void op2_Checked(object sender, RoutedEventArgs e)
        {
            if (_triggerCheckEvent )
            {
                //Get Selected Row
                int a = gameBodyList.SelectedIndex;

                //Mutate _lstQuestionViewModel
                _lstQuestionViewModel[a].chkOption1 = false;
                _lstQuestionViewModel[a].chkOption2 = true;
                _lstQuestionViewModel[a].chkOption3 = false;
                _lstQuestionViewModel[a].chkOption4 = false;

                //Refresh View
                RefreshDataGridView();
            } 

        }

        private void op2_Unchecked(object sender, RoutedEventArgs e)
        {
            //Get Selected Row
            int a = gameBodyList.SelectedIndex;

            //Mutate _lstQuestionViewModel
            _lstQuestionViewModel[a].chkOption2 = false;

            //Refresh View
            RefreshDataGridView(); 

        }

        private void op3_Checked(object sender, RoutedEventArgs e)
        {
            if (_triggerCheckEvent )
            {
                //Get Selected Row
                int a = gameBodyList.SelectedIndex;

                //Mutate _lstQuestionViewModel
                _lstQuestionViewModel[a].chkOption1 = false;
                _lstQuestionViewModel[a].chkOption2 = false;
                _lstQuestionViewModel[a].chkOption3 = true;
                _lstQuestionViewModel[a].chkOption4 = false;

                //Refresh View
                RefreshDataGridView();
            }

        }

        private void op3_Unchecked(object sender, RoutedEventArgs e)
        {
            //Get Selected Row
            int a = gameBodyList.SelectedIndex;

            //Mutate _lstQuestionViewModel
            _lstQuestionViewModel[a].chkOption3 = false;

            //Refresh View
            RefreshDataGridView(); 
        }

        private void op4_Checked(object sender, RoutedEventArgs e)
        {
            if ( _triggerCheckEvent )
            {
                //Get Selected Row
                int a = gameBodyList.SelectedIndex;

                //Mutate _lstQuestionViewModel
                _lstQuestionViewModel[a].chkOption1 = false;
                _lstQuestionViewModel[a].chkOption2 = false;
                _lstQuestionViewModel[a].chkOption3 = false;
                _lstQuestionViewModel[a].chkOption4 = true;

                //Refresh View
                RefreshDataGridView();
            } 

        }

        private void op4_Unchecked(object sender, RoutedEventArgs e)
        {
            //Get Selected Row
            int a = gameBodyList.SelectedIndex;

            //Mutate _lstQuestionViewModel
            _lstQuestionViewModel[a].chkOption4 = false;

            //Refresh View
            RefreshDataGridView(); 

        }





    }
}
