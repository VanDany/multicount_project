using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<string> UsersId { get; set; }
        public LocalUserUpdateDTO LocalUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
