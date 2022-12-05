using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetiSec.Controllers
{
    public class SupportController : Controller
    {
        private readonly LetiSecDB _db;

        public SupportController(LetiSecDB db)
        {
            _db = db;
        }

        public IActionResult ViewMessage()
        {
            return View();
        }

    }
}
