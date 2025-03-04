using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraction
{
    public interface IUserSessionRepository
    {
        void Add(UserSession userSession);
        UserSession? GetUserSession(string sessionId);
    }
}
