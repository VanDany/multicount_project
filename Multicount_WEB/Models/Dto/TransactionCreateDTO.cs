using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
{
    public class TransactionCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public string Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
