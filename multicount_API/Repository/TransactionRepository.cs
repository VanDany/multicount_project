using Microsoft.EntityFrameworkCore;
using multicount_API.Data;
using multicount_API.Models;
using multicount_API.Repository.IRepository;
using System.Linq.Expressions;

namespace multicount_API.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Transaction> UpdateAsync(Transaction entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Transactions.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
