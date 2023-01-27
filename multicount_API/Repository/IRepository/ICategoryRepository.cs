using multicount_API.Models;
using System.Linq.Expressions;

namespace multicount_API.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> UpdateAsync(Category entity);
    }
}
