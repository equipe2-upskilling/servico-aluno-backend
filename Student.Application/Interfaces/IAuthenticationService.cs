using Student.Application.Dtos;

namespace Student.Application.Interfaces
{
    public interface IAuthenticationService
    {
       Task<bool> CreateLogin(UserDto userDto);
       Task<bool> Login(UserDto userDto);
    }
}
