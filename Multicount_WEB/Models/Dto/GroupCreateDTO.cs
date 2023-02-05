using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
{
    public class GroupCreateDTO
    {
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        [Required]
        public string Description { get; set; }
        public List<string> GroupsUsers { get; set; }
    }
}
