using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Models.VM
{
    public class TransactionCreateVM
    {
        public TransactionCreateDTO Transaction { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public TransactionCreateVM()
        {
            Transaction = new TransactionCreateDTO();
        }
    }
}
