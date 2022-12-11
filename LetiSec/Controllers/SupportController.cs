using LetiSec.Models.DbModel;
using LetiSec.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LetiSec.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {
        private readonly LetiSecDB _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SupportController(LetiSecDB db, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        [Authorize(Roles = "admin,support")]
        public IActionResult Index()
        {
            IEnumerable<SuppMessage> messages = _db.SuppMessages.Where(u => u.IsAnswer == false);

            return View(messages);
        }

        [HttpGet]
        public IActionResult NewMessage(string mail)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == mail);
            SuppMessage message = new SuppMessage();
            message.UserId = user.Id;
            message.Email = user.Email;
            return View(message);
        }
        [HttpPost]
        public IActionResult NewMessage(SuppMessage message)
        {
            //добавить почту
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRoothPath = _webHostEnvironment.WebRootPath;
                //create
                if (files.Count != 0)
                {
                    string path = webRoothPath + WebConst.ImageProductPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(path, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    message.Img = fileName + extension;
                }
                message.IsAnswer = false;
                message.Date = DateTime.Now;
                _db.SuppMessages.Add(message);
                _db.SaveChanges();
                return RedirectToAction("SendMsg");
            }
            else
            {
                return View(message);
            }
        }

        public IActionResult SendMsg()
        {
            return View();
        }

    }
}
