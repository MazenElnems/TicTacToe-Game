using DataAccessLayer.Abstraction;
using GameLogicLayer.Abstraction;
using GameLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XOGame.Models;

namespace XOGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserSessionService _userSessionService;
        public HomeController(IUserSessionService userSessionService)
        {
            _userSessionService = userSessionService;
        }

        public IActionResult Index()
        {
            string? userSessionId = _userSessionService.GetUserSessionOrCreate(Response, Request);
            return RedirectToAction("Mode", "Game", new { userSession = userSessionId });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
