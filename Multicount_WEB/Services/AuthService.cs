using Microsoft.AspNetCore.Mvc;
using Multicount_Utility;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Services.IServices;

namespace Multicount_WEB.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string authUrl;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            authUrl = configuration.GetValue<string>("ServiceUrls:MulticountAPI");
        }
        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = authUrl + "/api/v2/UsersAuth/login"
            });
        }
        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = authUrl + "/api/v2/UsersAuth/register"
            });
        }
    }
}
