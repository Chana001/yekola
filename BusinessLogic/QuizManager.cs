using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class QuizManager : IQuizManager
    {
        public static List<int> alreadySelected;

        public bool addNewQuestion(Questions question)
        {
            bool result = false;
            if (QuizAccessor.addNewQuestion(question))
            {
                return result;

            }
            return true;
        }

        public List<Questions> retrieveQuestions(string category, int level)
        {
            var questionsList = new List<Questions>();

            //retrieve all questions matching input paramter criteria
            List<int> questionsIds = QuizAccessor.retrieveQuestionIds(category, level);

            //randomly select a fixed number of ids for actual question retrieval
            int[] chosenIds = new int[5]; //dummy number
            //ensure questions are not selected more than once in one session.


            //retrieve questions based on randomly selected numbers.
            questionsList = QuizAccessor.retireveQuestions(chosenIds);


            return questionsList;
        }

        public bool addNewCategory(Category category)
        {
            bool result = QuizAccessor.addNewCategory(category);

            return result;
        }

        public List<Category> retrieveCategories()
        {
            var categoryList = new List<Category>();

            categoryList = QuizAccessor.retrieveCategories();

            return categoryList;
        }

        public bool addNewLevel(Levels level)
        {
            bool result = QuizAccessor.addNewLevel(level);
            return result;
        }

        public List<Levels> retrieveLevels()
        {
            var levelList = new List<Levels>();

            levelList = QuizAccessor.retrieveLevels();

            return levelList;
        }

        public List<PlayerLevelCategory> getPlayerGameSummary(int userId)
        {
            var playerSummary = new List<PlayerLevelCategory>();

            playerSummary = QuizAccessor.getPlayerSummary(userId);


            return playerSummary;
        }

        public List<QuestionViewModel> GetGameData(int? levelId, string currentUser)
        {
            var questionList = new List<QuestionViewModel>();

            var questions = QuizAccessor.getGameData(levelId);
            QuestionViewModel qxtView;
            int no = 0;


            //Parse Into View Model

            if (currentUser.Equals("Player") )
            {
                foreach (var q in questions)
                {
                    no++;
                    qxtView = new QuestionViewModel()
                    {
                        QxnNo = no,
                        QuestionText = q.Text,
                        Option1 = q.Options[0].Text,
                       // chkOption1 = q.Options[0].IsCorrect,
                        Option2 = q.Options[1].Text,
                       // chkOption2 = q.Options[1].IsCorrect,
                        Option3 = q.Options[2].Text,
                        // chkOption3 = q.Options[2].IsCorrect,
                        Option4 = q.Options[3].Text,
                        // chkOption4 = q.Options[3].IsCorrect
                    };
                    questionList.Add(qxtView);
                }
            }
            else
            {
                foreach (var q in questions)
                {
                    no++;
                    qxtView = new QuestionViewModel()
                    {
                        QxnNo = no,
                        QuestionText = q.Text,
                        Option1 = q.Options[0].Text,
                        chkOption1 = q.Options[0].IsCorrect,
                        Option2 = q.Options[1].Text,
                        chkOption2 = q.Options[1].IsCorrect,
                        Option3 = q.Options[2].Text,
                        chkOption3 = q.Options[2].IsCorrect,
                        Option4 = q.Options[3].Text,
                        chkOption4 = q.Options[3].IsCorrect,

                    };
                    questionList.Add(qxtView);
                }
            }
            

            return questionList;
        }

        public bool SetupPlayer(string username)
        {
            bool result = false;
            bool isPassed = false;

            User user = UserAccessor.RetrieveUserByUsername( username );
            List<Levels> lstLevels = QuizAccessor.retrieveLevels();

            foreach ( var level in lstLevels )
            {
                QuizAccessor.CreateUserLevels(user.Id, level, isPassed );
            }

            //Set result
            result = true;

            return result;
        }

        public decimal GradePlayer( List<QuestionViewModel> lstQuestionViewModelFromPlayer, PlayerLevelCategory playerLevelCategory   )
        {
            //Bring in questions based on player level category
            List<QuestionViewModel> markingScheme = GetGameData(playerLevelCategory.LevelId, "NonPlayer");

            //Player Question Index
            int count = 0;

            //Player Grade or Marks
            decimal grade = 0;

            //Marking list
            List<bool> markingList;

            //Loop through marking scheme and grade.
            foreach( var k in markingScheme )
            {
                //Write information into a list
                markingList = new List<bool>();
                markingList.Add(k.chkOption1);
                markingList.Add(k.chkOption2);
                markingList.Add(k.chkOption3);
                markingList.Add(k.chkOption4);

                //Perform marking
                if ( markingList[0] == true && lstQuestionViewModelFromPlayer[count].chkOption1 == true )
                {
                    grade++;
                }
                else if (markingList[1] == true && lstQuestionViewModelFromPlayer[count].chkOption2 == true )
                {
                    grade++;
                }
                else if (markingList[2] == true && lstQuestionViewModelFromPlayer[count].chkOption3 == true )
                {
                    grade++;
                }
                else if (markingList[3] == true && lstQuestionViewModelFromPlayer[count].chkOption4 == true )
                {
                    grade++;
                }
                
                //Increase Player Question index
                count++;
            }


            //Calculate percentage
            grade =  ( ( grade ) / ( lstQuestionViewModelFromPlayer.Count ) ) * 100;

            //Unlock Current Level-Category in database
            bool success;
            if (grade > 90)
            {
                success = QuizAccessor.UnlockUserLevelsAndCategory(playerLevelCategory , true);
            }

            //Return grade to PL
            return grade;


            


        }




        public bool CheckPlay(int? userId, int? levelId)
        {
            int intUserId = userId ?? default(int);

            var playerSummary = getPlayerGameSummary(intUserId);

            foreach ( var a in playerSummary)
            {
                if (levelId == 3000)
                {
                    return true;
                }

                if (a.Unlocked == false)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
