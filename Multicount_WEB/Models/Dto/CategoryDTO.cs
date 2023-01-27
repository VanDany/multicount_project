using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
