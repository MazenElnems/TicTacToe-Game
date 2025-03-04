using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UserSession
    {
        [Key]
        public string SessionId { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
