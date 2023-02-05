using Multicount_Utility;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Models;
using Multicount_WEB.Services.IServices;
using Newtonsoft.Json.Linq;

namespace Multicount_WEB.Services
{
    public class GroupService : BaseService, IGroupService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string groupUrl;
        public GroupService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            groupUrl = configuration.GetValue<string>("ServiceUrls:MulticountAPI");
        }

        public Task<T> CreateAsync<T>(GroupCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data= dto,
                Url= groupUrl + "/api/v2/Group",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = groupUrl + "/api/v2/Group/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = groupUrl + "/api/v2/Group",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = groupUrl + "/api/v2/Group/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(GroupUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = groupUrl + "/api/v2/Group/" + dto.Id,
                Token = token
            });
        }
    }
}
