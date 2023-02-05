using Multicount_Utility;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Services.IServices;
using Newtonsoft.Json.Linq;

namespace Multicount_WEB.Services
{
    public class TransactionUserService : BaseService, ITransactionUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string transactionUserUrl;
        public TransactionUserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            transactionUserUrl = configuration.GetValue<string>("ServiceUrls:MulticountAPI");
        }

        public Task<T> CreateAsync<T>(TransactionUserCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data= dto,
                Url= transactionUserUrl + "/api/v1/TransactionUser",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = transactionUserUrl + "/api/v1/TransactionUser/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = transactionUserUrl + "/api/v1/TransactionUser",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = transactionUserUrl + "/api/v1/TransactionUser/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(TransactionUserUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = transactionUserUrl + "/api/v1/TransactionUser/" + dto.Id,
                Token = token
            });
        }
    }
}
