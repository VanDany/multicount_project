using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Models.VM
{
    public class CategoryUpdateVM
    {
        public CategoryUpdateDTO Category { get; set; }
        public CategoryUpdateVM()
        {
            Category = new CategoryUpdateDTO();
        }
    }
}
