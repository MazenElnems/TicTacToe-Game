using DataAccessLayer.Abstraction;
using DataAccessLayer.Entities;
using GameLogicLayer.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicLayer.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserSessionRepository _userSessionRepository;
        public UserSessionService(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public string? GetUserSessionOrCreate(HttpResponse response, HttpRequest request)
        {
            string sessionId; 
            if (request.Cookies.ContainsKey("user-token"))
            {
                sessionId = request.Cookies["user-token"];
            }
            else
            {
                sessionId = Guid.NewGuid().ToString("N");

                response.Cookies.Append("user-token", sessionId, new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(10),
                });

                UserSession userSession =  new UserSession
                {
                    SessionId = sessionId,
                    CreatedAt = DateTime.UtcNow
                };

                _userSessionRepository.Add(userSession);
            }

            return sessionId;
        }



    }
}
