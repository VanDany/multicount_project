using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Services.IServices
{
    public interface ICategoryService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CategoryCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(CategoryUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
