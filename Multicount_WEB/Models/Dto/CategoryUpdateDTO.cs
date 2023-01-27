using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
