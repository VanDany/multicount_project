using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace multicount_API.Models
{
    public class TransactionsUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        [ForeignKey("LocalUser")]
        public string UserId { get; set; }
        public LocalUser LocalUser { get; set; }
    }
}
