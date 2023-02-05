using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        [Required]
        public string Description { get; set; }
        public List<GroupsUsersDTO> GroupsUsers { get; set; }
    }
}
