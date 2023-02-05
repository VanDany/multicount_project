using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class GroupUpdateDTO
    {
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
