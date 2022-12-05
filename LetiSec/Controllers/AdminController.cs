using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LetiSec.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Identity;
using LetiSec.PassHashes;
using Microsoft.AspNetCore.Authorization;
using LetiSec.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LetiSec.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController:Controller
    {
        private readonly LetiSecDB _db;

        public AdminController(LetiSecDB db)
        {
            _db = db;
        }

        public IActionResult ViewUsers()
        {
            IEnumerable<User> users = _db.Users.Include(u => u.Role);
            
            return View(users);
        }

        [HttpGet]
        public IActionResult UserDetails(int id)
        {
            UserDetailsVM userDetailsVM = new UserDetailsVM()
            {
                User = _db.Users.Include(u => u.Role).Include(u => u.Orders).FirstOrDefault(u => u.Id == id),
                Roles = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            IEnumerable<Order> orders = _db.Orders.Include(u => u.Product).Where(u => u.UserId == userDetailsVM.User.Id);
            userDetailsVM.User.Orders = orders.ToList();

            return View(userDetailsVM);
        }

        [HttpPost]
        public IActionResult UserDetails(UserDetailsVM userDetailsVM)
        {
            User user = _db.Users.FirstOrDefault(u=>u.Id==userDetailsVM.User.Id);

            user.RoleId = userDetailsVM.User.RoleId;

            _db.Users.Update(user);
            _db.SaveChanges();

            return RedirectToAction("ViewUsers");
        }

    }
}
