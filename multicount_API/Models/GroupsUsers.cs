using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multicount_API.Models
{
    public class GroupsUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Group")]
        public int TransactionId { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
    }
}