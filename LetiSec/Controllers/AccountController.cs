using System.Collections.Generic;
using System.Threading.Tasks;
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

namespace LetiSec.Controllers
{
    public class AccountController:Controller
    {
        private LetiSecDB _db;
        private PasswordHash<User> _hashPass;

        public AccountController(LetiSecDB context)
        {
            _db = context;
            _hashPass = new PasswordHash<User>();
        }


        [Authorize]
        public IActionResult Home()
        {
            //поменять order
            string name = User.Identity.Name;

            User user = _db.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == name);
            IEnumerable<Order> orders = _db.Orders.Include(u => u.Product).Where(u => u.UserId == user.Id);
            user.Orders = orders.ToList();

            return View(user);
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == userModel.Email);
                if (user == null)
                {

                    string hash = _hashPass.HashPas(user, userModel.Password);
                    user = new User { Email = userModel.Email, Name = userModel.Name, Password =hash, RoleId = 2 };
                    _db.Users.Add(user);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("LogIn", "Account");
                }
                else
                    ModelState.AddModelError("", "К данной почте аккаунт уже привязан");
            }
            return View(userModel);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> LogIn(LoginModel loginUser)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<User> password = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
                
                User user = _db.Users.Include(u=>u.Role).FirstOrDefault(u => u.Email == loginUser.Email);

                if (user != null)
                {
                    bool checkPass = _hashPass.CheckPass(user, user.Password, loginUser.Password);

                    if(checkPass)
                    {
                        
                        await Authenticate(loginUser.Email, user.Role.Name);
                        return RedirectToAction("Home", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Некорректные логин и(или) пароль");

                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(loginUser);
        }


        [Authorize]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Home");
        }

        private async Task Authenticate(string userName, string Role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
