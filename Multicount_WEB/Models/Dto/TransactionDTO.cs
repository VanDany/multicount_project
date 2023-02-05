using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Multicount_WEB.Models.Dto
{
    public class TransactionDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public int GroupId { get; set; }
        public CategoryDTO Category { get; set; }
        public LocalUserUpdateDTO LocalUser { get; set; }
        public List<TransactionUserDTO> TransactionsUsers { get; set; }
        [Required]
        public string Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
