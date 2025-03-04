using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicLayer.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Board { get; set; } = new string(' ', 9);
        public char CurrentSymbol { get; set; }
        public DateTime CreatedAt { get; set; }
        public GameStatus Status { get; set; }
        public GameType TypeOfGame { get; set; }
        public string SessionId { get; set; }
    }
}
