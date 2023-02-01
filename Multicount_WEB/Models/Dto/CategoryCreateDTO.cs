using System.ComponentModel.DataAnnotations;

namespace Multicount_WEB.Models.Dto
{
    public class CategoryCreateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
