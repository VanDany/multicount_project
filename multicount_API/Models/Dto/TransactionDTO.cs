using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class TransactionDTO
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public CategoryDTO Category { get; set; }
        public LocalUser LocalUser { get; set; }
        public List<TransactionsUsers> TransactionsUsers { get; set; }

    }
}
