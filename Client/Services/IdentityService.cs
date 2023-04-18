using Client.Models;
using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Client.Services
{
    public class IdentityService
    {
        private readonly HttpClient httpClient;

        public IdentityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> LoginSend(LoginDTO lg)
        {
            var response = await httpClient.PostAsJsonAsync("api/profile/FoundingUser", lg);

            return response.ReasonPhrase;
        }

        public async Task<string> RegisterSend(RegistrationDTO reg)
		{
			var result = await httpClient.PostAsJsonAsync("api/profile/RegUser", reg);

            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();
            return result.ReasonPhrase;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var response = await httpClient.GetFromJsonAsync<User>($"api/profile/GetUserByEmail/{email}");

            return response;
        }

        public async Task ChangeName(ChangeNameModel user)
        {
            var response = await httpClient.PutAsJsonAsync($"api/profile/ChangeName/{user.Email}", user.UserName);         
        }

        public async Task<bool> CheckName(string name)
        {
            var response = await httpClient.GetAsync($"api/profile/CheckName/{name}");

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
