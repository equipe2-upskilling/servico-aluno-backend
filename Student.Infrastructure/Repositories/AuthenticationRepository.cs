using Newtonsoft.Json;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using System.Net;
using System.Net.Http.Headers;
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
        public async Task<bool> CreateLogin(string email, string password)
        {
            var urlBase = _apiUrl + "/register";
            using HttpClient? client = new();
            string? conteudo = "";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage? respToken =
                await client.PostAsync(urlBase, new StringContent(
                    JsonConvert.SerializeObject(new
                    {
                        email,
                        password
                    }), Encoding.UTF8, "application/json"));
            try
            {
                conteudo = await respToken.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            return respToken.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> Login(string email, string password)
        {
            var urlBase = _apiUrl + "/login";
            using HttpClient client = new();
            string? conteudo = "";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage? respToken =
                await client.PostAsync(urlBase, new StringContent(
                    JsonConvert.SerializeObject(new
                    {
                        email,
                        password
                    }), Encoding.UTF8, "application/json"));
            try
            {
                conteudo = await respToken.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }

            if (respToken.StatusCode == HttpStatusCode.OK)
            {
                accessToken = JsonConvert.DeserializeObject<AccessToken>(conteudo);
                if (accessToken.Authenticated)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
                    return true;
                }
            }
            return false;
        }
    }
}
