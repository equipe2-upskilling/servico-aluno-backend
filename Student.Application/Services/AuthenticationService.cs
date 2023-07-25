using AutoMapper;
using Student.Application.Dtos;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Domain.Interfaces;

namespace Student.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateLogin(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _authenticationRepository.CreateLogin(user);
            if(result)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Login(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _authenticationRepository.Login(user);
            if (result)
            {
                return true;
            }
            return false;
        }
    }
}
