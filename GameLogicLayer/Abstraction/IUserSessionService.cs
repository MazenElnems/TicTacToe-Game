using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogicLayer.Abstraction
{
    public interface IUserSessionService
    {
        string? GetUserSessionOrCreate(HttpResponse response, HttpRequest request);
    }
}
