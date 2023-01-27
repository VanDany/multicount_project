using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
