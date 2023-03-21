using CryptoShoto.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Client.Services
{
    public class LoginService
    {
        private readonly HttpClient httpClient;
        private HttpContext context;

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> LoginSend(LoginDTO lg)
        {
            var response = await httpClient.PostAsJsonAsync("api/profile/IsAuthenticated", lg);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

		public async Task<bool> RegisterSend(RegistrationDTO reg)
		{
			var result = await httpClient.PostAsJsonAsync("api/profile/add", reg);
			if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
		}
	}
}
