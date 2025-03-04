using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _db;
        public GameRepository(AppDbContext db)
        {
            _db = db;
        }
        public Game? GetGameById(int id) 
        {
            return _db.Games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetAllGames(string sessionId) 
        {
            return _db.Games.Where(g => g.SessionId == sessionId);
        }

        public Game CreateGame(Game game)
        {
            _db.Games.Add(game);
            SaveGame();
            return game;   
        }

        public void SaveGame()
        {
            _db.SaveChanges();
        }
    }
}
