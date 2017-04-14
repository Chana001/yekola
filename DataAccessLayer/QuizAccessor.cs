using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class QuizAccessor
    {
        //Admin  retrieval features
        public static bool addNewQuestion(Questions question)
        {
            //store procedure to add a new question
            return true;
        }

        public static  bool addNewCategory(Category category)
        {
            //stored procedure to add a new category
            return true;
        }

        public static List<Category> retrieveCategories()
        {
            //stored procedure to retrieve all available categories
            return new List<Category>();
        }

        public static bool addNewLevel(Levels level)
        {
            //stored procedure to add a new level
            return true;
        }

        public static List<Levels> retrieveLevels()
        {
            var lstLevels = new List<Levels>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_levels";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lstLevels.Add(new Levels()
                        {
                             Id = reader.GetInt32(0),
                             Name = reader.GetString(1),
                             CategoryID = reader.GetString(2),
                             Description = reader.GetString(3)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return lstLevels;
        }

        public static List<Questions> retireveQuestions(int[] questionsIds) //automatically generated indexes expected from the business layer
        {
            var questionsList = new List<Questions>();
            //stored procedure to retrieve questions from indexes provided from business layer.
            return questionsList;
        }

        public static List<int> retrieveQuestionIds(string  category, int level)
        {
            //retieves a list of integers from database based on category and level

            //stored procedure to retrieve all ids matching category and level criteria

            //add to list and return to business layer
            return new List<int>();
        }

        public static List<PlayerLevelCategory> getPlayerSummary(int userId)
        {
            var playerSummary = new List<PlayerLevelCategory>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_player_summary";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UsersID", SqlDbType.Int);
            cmd.Parameters["@UsersID"].Value = userId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        playerSummary.Add(new PlayerLevelCategory()
                        {
                            LevelId = reader.GetInt32(0),
                            Level = reader.GetString(1),
                            Category = reader.GetString(2),
                            Unlocked = reader.GetBoolean(3)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return playerSummary;
        }

        public static List<Questions> getGameData(int levelId)
        {
            var questionList = new List<Questions>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_questions";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LevelsId", SqlDbType.Int);
            cmd.Parameters["@LevelsId"].Value = levelId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        questionList.Add(new Questions()
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }


            // Add Options Information
            List<Options> optionsInDB;
            List<Options> opList; //= new List<Options>();
            int count = 0;
            foreach (  var q in questionList )
            {
                optionsInDB = new List<Options>();
                optionsInDB = RetrieveOptionsByQuestionID(q.Id);
                questionList[count].Options = optionsInDB;

                count++;                
            }

            return questionList;
        }

        private static List<Options> RetrieveOptionsByQuestionID(int questionsId)
        {
            var optionsList = new List<Options>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_options_by_questionId";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionsID", SqlDbType.Int);
            cmd.Parameters["@QuestionsID"].Value = questionsId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        optionsList.Add(new Options()
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1),
                            QuestionId = reader.GetInt32(2),
                            IsCorrect = reader.GetBoolean(3)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return optionsList;
        }

        public static bool CreateUserLevels(int userID, Levels level, bool isPassed)
        {

            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_create_user_levels";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsersID", userID);
            cmd.Parameters.AddWithValue("@LevelsID", level.Id);
            cmd.Parameters.AddWithValue("@IsPassed", isPassed);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            //Returns the User ID
            bool result = count == 1 ? true : false;

            return result;
        }

        public static bool UnlockUserLevelsAndCategory(PlayerLevelCategory playerLevelCategory, bool isPassed)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_update_user_levels";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsersID", playerLevelCategory.UserID);
            cmd.Parameters.AddWithValue("@LevelsID", playerLevelCategory.LevelId);
            cmd.Parameters.AddWithValue("@IsPassed", isPassed);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            //Returns the User ID
            bool result = count == 1 ? true : false;

            return result;
        }
    }
}
