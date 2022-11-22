using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LetiSec.Models.ViewModels
{
    public class ProductVM
    {
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public Product Product { get; set; }
    }
}
