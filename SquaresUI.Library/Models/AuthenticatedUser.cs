using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Models
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public string UserName { get; set; }
        public string Access_Token { get; set; }
    }
}
