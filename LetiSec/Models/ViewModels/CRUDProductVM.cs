using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LetiSec.Models.ViewModels
{
    public class CRUDProductVM
    {
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public Product Product { get; set; }
    }
}
