using multicount_API.Data;
using multicount_API.Models;
using multicount_API.Repository.IRepository;

namespace multicount_API.Repository
{
    public class LocalUserRepository : Repository<LocalUser>, ILocalUserRepository
    {
        private readonly ApplicationDbContext _db;
        public LocalUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<LocalUser> UpdateAsync(LocalUser entity)
        {
            _db.LocalUsers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
