using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Models.VM
{
    public class CategoryDeleteVM
    {
        public CategoryDTO Category { get; set; }
        public CategoryDeleteVM()
        {
            Category = new CategoryDTO();
        }
    }
}
