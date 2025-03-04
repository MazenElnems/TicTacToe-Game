using DataAccessLayer.Abstraction;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Enums;
using GameLogicLayer.Abstraction;
using GameLogicLayer.DTOs;
using System.Linq;

namespace GameLogicLayer.Managers
{
    public class GameManager : IGameManager
    {
        private readonly IGameRepository _gameRepository;
        public GameManager(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public GameDTO CreateGame(string userSession, GameType type)
        {
            Game game = new Game
            {
                CreatedAt = DateTime.Now,
                Board = new string(' ', 9),
                CurrentSymbol = 'X',
                Status = GameStatus.InProgress,
                TypeOfGame = type,
                SessionId = userSession
            };

            game = _gameRepository.CreateGame(game);

            return new GameDTO
            {
                Board = game.Board,
                CreatedAt = game.CreatedAt,
                CurrentSymbol = game.CurrentSymbol,
                Status = game.Status,
                TypeOfGame = type,
                Id = game.Id,
                SessionId = userSession,
            };
        }

        public GameDTO? GetGame(int id)
        {
            Game? game = _gameRepository.GetGameById(id);
            return game == null ? null : new GameDTO
            {
                Id = id,
                Board = game.Board,
                CreatedAt = game.CreatedAt,
                CurrentSymbol = game.CurrentSymbol,
                Status = game.Status,
                TypeOfGame = game.TypeOfGame,
                SessionId = game.SessionId,
            };
        }

        public void Move(int id, int index)
        {
            Game? game = _gameRepository.GetGameById(id);
            if (game != null && index >= 0 && index <= 8 && char.IsWhiteSpace(game.Board[index]))
            {
                char[] boardArr = game.Board.ToCharArray();
                boardArr[index] = game.CurrentSymbol;
                game.Board = new string(boardArr);

                if (CheckWin(game, game.CurrentSymbol))
                {
                    game.Status = game.CurrentSymbol == 'X' ? GameStatus.XWin : GameStatus.OWin;
                }
                else if (IsBoardFilled(game))
                {
                    game.Status = GameStatus.Draw;
                }
                else
                {
                    game.CurrentSymbol = game.CurrentSymbol == 'X' ? 'O' : 'X';
                }
                _gameRepository.SaveGame();

            }
        }

        public void AIMove(int id)
        {
            Game? game = _gameRepository.GetGameById(id);
            if (game != null && game.Status == GameStatus.InProgress)
            {
                int bestMove = GetBestMove(game);
                if (bestMove != -1)
                {
                    Move(id, bestMove);
                }
            }
        }

        public IEnumerable<GameDTO> GetAllGames(string sessionId)
        {
            return _gameRepository.GetAllGames(sessionId)
                .Select(x => new GameDTO
                {
                    Board = x.Board,
                    CreatedAt = x.CreatedAt,
                    CurrentSymbol = x.CurrentSymbol,
                    Id = x.Id,
                    Status = x.Status,
                    TypeOfGame = x.TypeOfGame,
                    SessionId = sessionId,
                });
        }

        private bool CheckWin(Game game, char symbol)
        {
            string board = game.Board;
            return (board[0] == symbol && board[1] == symbol && board[2] == symbol) ||
                   (board[3] == symbol && board[4] == symbol && board[5] == symbol) ||
                   (board[6] == symbol && board[7] == symbol && board[8] == symbol) ||
                   (board[0] == symbol && board[3] == symbol && board[6] == symbol) ||
                   (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                   (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                   (board[0] == symbol && board[4] == symbol && board[8] == symbol) ||
                   (board[2] == symbol && board[4] == symbol && board[6] == symbol);
        }

        private bool IsBoardFilled(Game game) => game.Board.All(x => !char.IsWhiteSpace(x));

        private int GetBestMove(Game game)
        {
            int bestScore = int.MaxValue;
            int bestMove = -1;

            for (int i = 0; i < 9; i++)
            {
                if (char.IsWhiteSpace(game.Board[i]))
                {
                    char[] boardArr = game.Board.ToCharArray();
                    boardArr[i] = 'O'; 
                    int score = Minimax(new string(boardArr), true, 0); 
                    if (score < bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }
            return bestMove;
        }

        private int Minimax(string board, bool isMaximizing, int depth)
        {
            if (CheckWin(new Game { Board = board} , 'X')) return 10 - depth;
            if (CheckWin(new Game { Board = board} , 'O')) return depth - 10;
            if (board.All(c => !char.IsWhiteSpace(c))) return 0;

            int bestScore = isMaximizing ? int.MinValue : int.MaxValue;
            char currentPlayer = isMaximizing ? 'X' : 'O';

            for (int i = 0; i < 9; i++)
            {
                if (char.IsWhiteSpace(board[i]))
                {
                    char[] boardArr = board.ToCharArray();
                    boardArr[i] = currentPlayer;
                    int score = Minimax(new string(boardArr), !isMaximizing, depth + 1);
                    bestScore = isMaximizing ? Math.Max(score, bestScore) : Math.Min(score, bestScore);
                }
            }
            return bestScore;
        }

    }
}
