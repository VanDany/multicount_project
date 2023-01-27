using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class CategoryCreateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
