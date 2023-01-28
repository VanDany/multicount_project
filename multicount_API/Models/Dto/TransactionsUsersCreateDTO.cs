using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class TransactionsUsersCreateDTO
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }
    }
}
