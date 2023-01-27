using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class TransactionUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public float Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
