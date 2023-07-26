using Student.Domain.Entities;

namespace Student.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> CreateLogin(User user);
    }
}
