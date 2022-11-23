
using LetiSec.Models.DbModel;

namespace LetiSec.Models.ViewModels
{
    public class ProductVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
