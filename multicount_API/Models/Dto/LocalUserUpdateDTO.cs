using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class LocalUserUpdateDTO
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
