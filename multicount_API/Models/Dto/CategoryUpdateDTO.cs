using System.ComponentModel.DataAnnotations;

namespace multicount_API.Models.Dto
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
