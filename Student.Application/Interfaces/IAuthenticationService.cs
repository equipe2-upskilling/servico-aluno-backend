using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Interfaces
{
    public interface IAuthenticationService
    {
       Task<bool> CreateLogin(string email, string password);
       Task<bool> Login(string email, string password);
    }
}
