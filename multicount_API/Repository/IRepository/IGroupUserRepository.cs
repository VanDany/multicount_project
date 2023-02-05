using multicount_API.Models;
using System.Linq.Expressions;

namespace multicount_API.Repository.IRepository
{
    public interface IGroupUserRepository : IRepository<GroupsUsers>
    {
        Task<GroupsUsers> UpdateAsync(GroupsUsers entity);
    }
}
