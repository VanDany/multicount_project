using Microsoft.EntityFrameworkCore;
using multicount_API.Data;
using multicount_API.Models;
using multicount_API.Repository.IRepository;
using System.Linq.Expressions;

namespace multicount_API.Repository
{
    public class GroupsUsersRepository : Repository<GroupsUsers>, IGroupUserRepository
    {
        private readonly ApplicationDbContext _db;
        public GroupsUsersRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<GroupsUsers> UpdateAsync(GroupsUsers entity)
        {
            _db.GroupsUsers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
