using multicount_API.Data;
using multicount_API.Models;
using multicount_API.Repository.IRepository;

namespace multicount_API.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly ApplicationDbContext _db;
        public GroupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Group> UpdateAsync(Group entity)
        {
            _db.Groups.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
