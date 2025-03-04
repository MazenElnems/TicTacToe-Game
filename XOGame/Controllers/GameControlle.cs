using DataAccessLayer.Entities.Enums;
using GameLogicLayer.Abstraction;
using GameLogicLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using XOGame.VMs;

namespace XOGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameManager _gameManager;
        public GameController(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public IActionResult Index(string userSession, int type)
        {
            if (string.IsNullOrEmpty(userSession) || !Enum.IsDefined(typeof(GameType), type))
            {
                return RedirectToAction("Error", "Home");
            }

            GameDTO gameDTO = _gameManager.CreateGame(userSession, (GameType)type);
            return RedirectToAction(nameof(Play), new { id = gameDTO.Id });
        }

        public IActionResult Play(int id)
        {
            GameDTO? gameDTO = _gameManager.GetGame(id);

            if(gameDTO != null)
            {
                GameVM gameVM = new GameVM
                {
                    Board = gameDTO.Board,
                    CreatedAt = gameDTO.CreatedAt,
                    CurrentSymbol = gameDTO.CurrentSymbol,
                    Id = gameDTO.Id,
                    Status = gameDTO.Status,
                    SessionId = gameDTO.SessionId,  
                    TypeOfGame = gameDTO.TypeOfGame,
                };

                return View(gameVM);
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult Mode(string userSession) 
        {
            return View(nameof(Mode),userSession);
        }

        public IActionResult Move(int id, int index)
        {
            var game = _gameManager.GetGame(id);
            if (game == null || game.SessionId != Request.Cookies["user-token"])
            {
                return RedirectToAction("Error", "Home");
            }
            _gameManager.Move(id, index);

            if (game.TypeOfGame == GameType.Single && game.CurrentSymbol == 'X') 
                _gameManager.AIMove(id);
            
            return RedirectToAction(nameof(Play), new { id });
        }

        public IActionResult History(string userSession)
        {
            var games = _gameManager.GetAllGames(userSession);

            games = games.Where(g => g.Board.Contains('X') || g.Board.Contains('O'));
            if(games !=  null)
            {
                return View(games);
            }
            return RedirectToAction("Error", "Home");
        }

    }
}
