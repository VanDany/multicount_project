using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class TransactionCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public float Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
