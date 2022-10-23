using LetiSec.Models;
using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace LetiSec.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db;
        public HomeController(UserContext db)
        {
            this.db = db;
        }

        public IActionResult Home()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {


            string name = User.Identity.Name;
            string role = User.FindFirst(p => p.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            List < string >user= new List<string> { name, role };

            return View("Index",user);
        }

        [Authorize(Roles ="admin")]
        public IActionResult Info()
        {
            
                var users = (from role in db.Roles
                             join user in db.Users on role.Id equals user.RoleId
                             select new { Name = user.Name, Mail = user.Email, Role = role.Name }
                           ).ToList();

                return View(users);
            
        }

       
       
    }
}