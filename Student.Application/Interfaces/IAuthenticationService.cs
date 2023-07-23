namespace Student.Application.Interfaces
{
    public interface IAuthenticationService
    {
       Task<bool> CreateLogin(string email, string password);
       Task<bool> Login(string email, string password);
    }
}
