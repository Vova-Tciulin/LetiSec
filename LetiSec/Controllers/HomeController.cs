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
        private LetiSecDB _db;
        public HomeController(LetiSecDB db)
        {
           _db = db;
        }

        public IActionResult Home()
        {
            return View();
        }

       

       
       
    }
}