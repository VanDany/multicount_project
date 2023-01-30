using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Models.VM
{
    public class CategoryCreateVM
    {
        public LocalUserCreateDTO Category { get; set; }
        public CategoryCreateVM()
        {
            Category = new LocalUserCreateDTO();
        }
    }
}
