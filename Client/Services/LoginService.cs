using CryptoShoto.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Client.Services
{
    public class LoginService
    {
        private readonly HttpClient httpClient;

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task LoginSend(LoginDTO lg)
        {
            await httpClient.PostAsJsonAsync("api/profile", lg);
        }
        
        public async Task<bool> Bool()
        {
            var response = await httpClient.GetAsync("api/profile/IsAuthenticated");

            if (response.IsSuccessStatusCode)
            {
                bool isAuthenticated = await response.Content.ReadFromJsonAsync<bool>();

                if (isAuthenticated)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
