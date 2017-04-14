using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;

namespace MVCPresentationLayer.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizManager _quizManager = new QuizManager();

        // GET: Main Quiz View
        public ActionResult Index()
        {
            var summary = _quizManager.getPlayerGameSummary(1001);

            return View(summary);
        }

        public ActionResult MainQuiz()
        {

            var gameData = _quizManager.getGameData(3000, "F002");

            return View(gameData);

        }
    }
}