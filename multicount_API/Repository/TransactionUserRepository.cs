using Microsoft.EntityFrameworkCore;
using multicount_API.Data;
using multicount_API.Models;
using multicount_API.Repository.IRepository;
using System.Linq.Expressions;

namespace multicount_API.Repository
{
    public class TransactionUserRepository : Repository<TransactionsUsers>, ITransactionUserRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<TransactionsUsers> UpdateAsync(TransactionsUsers entity)
        {
            _db.TransactionsUsers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
