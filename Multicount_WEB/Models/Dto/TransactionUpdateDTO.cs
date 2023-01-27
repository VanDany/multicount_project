using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
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
        public string Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
