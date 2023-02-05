using multicount_API.Models;
using System.Linq.Expressions;

namespace multicount_API.Repository.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> UpdateAsync(Group entity);
    }
}
