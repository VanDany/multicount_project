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
        public int GroupId { get; set; }
        [ForeignKey("LocalUser")]
        public int UserId { get; set; }
        public float Amount { get; set; }
    }
}