using multicount_API.Models;

namespace multicount_API.Repository.IRepository
{
    public interface ILocalUserRepository : IRepository<LocalUser>
    {
        Task<LocalUser> UpdateAsync(LocalUser entity);
    }
}
