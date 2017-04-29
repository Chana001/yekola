using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic;
using DataObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCPresentationLayer.Models;

namespace MVCPresentationLayer.Controllers
{
    public class QuizController : Controller
    {
        private readonly UserManager _userManager = new UserManager();


        private readonly IQuizManager _quizManager = new QuizManager();

        // GET: Main Quiz View
        [Authorize]
        public ActionResult Index()
        {
            //get current user by context
            var username = User.Identity.GetUserName().ToUpper();

            var user = _userManager.RetrieveUserByUsername(username);
            var summary = _quizManager.getPlayerGameSummary(user.Id);

            return View(summary);
        }

        public ActionResult MainQuiz(int? levelId)
        {
            //get current user by context
            var username = User.Identity.GetUserName().ToUpper();
            var user = _userManager.RetrieveUserByUsername(username);
            var roles = _userManager.GetUserRoles(user.Id);

            List<QuestionViewModel> gameData;

            try
            {
                gameData = _quizManager.GetGameData(levelId, roles[0].Id);
                bool canPlay = _quizManager.CheckPlay(user.Id, levelId);

                if (canPlay == false)
                {
                    return View("Blocked");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View("Error");
            }

            return gameData != null ? View(gameData) : View();
        }

        [HttpPost]
        public ActionResult SaveAnswer()
        {
            throw new NotImplementedException();
        }
    }
}