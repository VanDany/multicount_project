using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class GroupCreateDTO
    {
        public int Id { get; set; }
        [Required]
        public string CreatorUserId { get; set; }
        public string Description { get; set; }
    }
}
