using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Services.IServices
{
    public interface IGroupService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(GroupCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(GroupUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
