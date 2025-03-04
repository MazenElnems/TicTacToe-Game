using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }    
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }


    }
}
