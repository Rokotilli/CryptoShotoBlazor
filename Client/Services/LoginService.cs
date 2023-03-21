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

        public async Task<string> LoginSend(LoginDTO lg)
        {
            var response = await httpClient.PostAsJsonAsync("api/profile/IsAuthenticated", lg);
            Console.WriteLine(response.ReasonPhrase);
            return response.ReasonPhrase;
        }

		public async Task<string> RegisterSend(RegistrationDTO reg)
		{
			var result = await httpClient.PostAsJsonAsync("api/profile/add", reg);

            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();
            return result.ReasonPhrase;
        }
	}
}
