using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LetiSec.Models.ViewModels
{
    public class UserDetailsVM
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
