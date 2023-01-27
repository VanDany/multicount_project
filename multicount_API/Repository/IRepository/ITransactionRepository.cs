using multicount_API.Models;
using System.Linq.Expressions;

namespace multicount_API.Repository.IRepository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<Transaction> UpdateAsync(Transaction entity);
    }
}
