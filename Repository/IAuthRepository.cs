using AuthenticationService.DTO;
using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Repository
{
    public interface IAuthRepository
    {
        AuthenticatedUserDTO Login(LoginModel loginModel);
    }
}
