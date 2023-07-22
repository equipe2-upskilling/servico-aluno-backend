using Student.Application.Interfaces;
using Student.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<bool> CreateLogin(string email, string password)
        {
            await _authenticationRepository.CreateLogin(email, password);
            return true;
        }

        public async Task<bool> Login(string email, string password)
        {
            await _authenticationRepository.Login(email, password);
            return true;
        }
    }
}
