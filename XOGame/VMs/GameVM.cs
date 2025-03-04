using DataAccessLayer.Entities.Enums;

namespace XOGame.VMs
{
    public class GameVM
    {
        public int Id { get; set; }
        public string Board { get; set; } = new string(' ', 9);
        public char CurrentSymbol { get; set; }
        public DateTime CreatedAt { get; set; }
        public GameStatus Status { get; set; }
        public string SessionId { get; set; }
        public GameType TypeOfGame { get; set; }
    }
}
