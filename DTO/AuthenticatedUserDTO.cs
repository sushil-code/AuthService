using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DTO
{
    public class AuthenticatedUserDTO
    {
        public string Token { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
    }
}
