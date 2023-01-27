using Multicount_Utility;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Services.IServices;

namespace Multicount_WEB.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string transactionUrl;
        public TransactionService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            transactionUrl = configuration.GetValue<string>("ServiceUrls:MulticountAPI");
        }

        public Task<T> CreateAsync<T>(TransactionCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data= dto,
                Url= transactionUrl+"/api/v2/Transaction",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = transactionUrl + "/api/v2/Transaction/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = transactionUrl + "/api/v1/Transaction",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = transactionUrl + "/api/v1/Transaction/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(TransactionUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = transactionUrl + "/api/v2/Transaction/" + dto.Id,
                Token = token
            });
        }
    }
}
