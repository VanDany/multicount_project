using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Services.IServices
{
    public interface ITransactionService
    {
        Task<T> GetAllAsync<T>(int groupId, string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(TransactionCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(TransactionUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
