using DataAccessLayer.Entities.Enums;
using GameLogicLayer.DTOs;


namespace GameLogicLayer.Abstraction
{
    public interface IGameManager
    {
        GameDTO? GetGame(int id);
        void Move(int id, int index);
        IEnumerable<GameDTO> GetAllGames(string sessionId);
        GameDTO CreateGame(string userSession, GameType type);
        void AIMove(int id);
    }
}
