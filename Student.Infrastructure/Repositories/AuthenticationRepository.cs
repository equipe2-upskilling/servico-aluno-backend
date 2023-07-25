using Newtonsoft.Json;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Student.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private static AccessToken? accessToken;
        private static string? _apiUrl;

        public AuthenticationRepository()
        {
            _apiUrl = "https://localhost:44379";
        }
        public async Task<bool> CreateLogin(User user)
        {
            var urlBase = _apiUrl + "/register";
            using HttpClient? client = new();

            try
            {
                var response = await client.PostAsJsonAsync(urlBase,user);
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            return false;
            
        }

        public async Task<bool> Login(User user)
        {
            var urlBase = _apiUrl + "/login";
            using HttpClient client = new();

            try
            {
                var response = await client.PostAsJsonAsync(urlBase,user);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }

            return false;
        }
    }
}
