using DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [MaxLength(9)]
        public string Board { get; set; } = new string(' ', 9);
        public char CurrentSymbol { get; set; }
        public DateTime CreatedAt { get; set; }
        public GameStatus Status { get; set; }
        public GameType TypeOfGame { get; set; }
        public string SessionId { get; set; }   
        public UserSession Session { get; set; }
    }
}
