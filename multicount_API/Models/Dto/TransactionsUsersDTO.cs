using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multicount_API.Models.Dto
{
    public class TransactionsUsersDTO
    {
        [Key]
        public string Id { get; set; }
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public LocalUser LocalUser { get; set; }
        public Transaction Transaction { get; set; }
        public TransactionsUsers TransactionUser { get; set; }
    }
}
