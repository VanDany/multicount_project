using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Multicount_WEB.Models.Dto
{
    public class TransactionUserDTO
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public LocalUserDTO LocalUser { get; set; }
    }
}
