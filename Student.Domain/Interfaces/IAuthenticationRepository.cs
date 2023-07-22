namespace Student.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> CreateLogin(string email, string password);
        Task<bool> Login(string email, string password);
    }
}
