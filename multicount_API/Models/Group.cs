using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multicount_API.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        public string Description { get; set; }
        public List<GroupsUsers> GroupsUsers { get; set; }
    }
}
