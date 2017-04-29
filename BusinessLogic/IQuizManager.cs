using System.Collections.Generic;
using DataObjects;

namespace BusinessLogic
{
    public interface IQuizManager
    {

        bool addNewQuestion(Questions question);

        List<Questions> retrieveQuestions(string category, int level);

        bool addNewCategory(Category category);

        List<Category> retrieveCategories();

        bool addNewLevel(Levels level);

        List<Levels> retrieveLevels();

        List<PlayerLevelCategory> getPlayerGameSummary(int userId);

        List<QuestionViewModel> GetGameData(int? levelId, string currentUser);

        bool SetupPlayer(string username);

        decimal GradePlayer(List<QuestionViewModel> lstQuestionViewModelFromPlayer, PlayerLevelCategory playerLevelCategory);

        bool CheckPlay(int? userId, int? levelId);
    }
}