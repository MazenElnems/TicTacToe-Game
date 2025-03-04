using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserSessionRepository : IUserSessionRepository
    {
        private readonly AppDbContext _db;

        public UserSessionRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(UserSession userSession)
        {
            _db.UserSessions.Add(userSession);
            _db.SaveChanges();
        }

        public UserSession? GetUserSession(string sessionId)
        {
            return _db.UserSessions.SingleOrDefault(x => x.SessionId == sessionId);
        }
    }
}
