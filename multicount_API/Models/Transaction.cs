using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static multicount_API.Repository.TransactionRepository;

namespace multicount_API.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        [ForeignKey("LocalUser")]
        public string UserId { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Category Category { get; set; }
        public LocalUser LocalUser { get; set; }
        public List<TransactionsUsers> TransactionsUsers { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
