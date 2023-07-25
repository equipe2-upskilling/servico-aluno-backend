using Student.Domain.Entities;

namespace Student.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> CreateLogin(User user);
        Task<bool> Login(User user);
    }
}
