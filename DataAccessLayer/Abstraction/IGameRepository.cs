using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraction
{
    public interface IGameRepository
    {
        Game? GetGameById(int id);
        IEnumerable<Game> GetAllGames(string sessionId);
        Game CreateGame(Game game);
        void SaveGame();
    }
}
