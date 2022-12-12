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
        [Authorize(Roles = "admin,support")]
        public IActionResult ViewAllSupp()
        {
            IEnumerable<SuppMessage> messages = _db.SuppMessages;

            return View(messages);
        }

        [HttpGet]
        public IActionResult NewMessage(string mail)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == mail);
            SuppMessage message = new SuppMessage();
            message.UserId = user.Id;
            message.Email = user.Email;
            SupportVM support = new SupportVM();
            support.SuppMessage = message;

            return View(support);
        }
        [HttpPost]
        public IActionResult NewMessage(SupportVM message)
        {
            //добавить почту
            if (message.Questions!=null||message.SuppMessage.ShortDescription!=null)
            {
                var files = HttpContext.Request.Form.Files;
                string webRoothPath = _webHostEnvironment.WebRootPath;
                //create
                if (files.Count != 0)
                {
                    string path = webRoothPath + WebConst.ImageSupportPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(path, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    message.SuppMessage.Img = fileName + extension;
                }
                message.SuppMessage.IsAnswer = false;
                message.SuppMessage.IsFirst = true;
               
                message.SuppMessage.Time = DateTime.Now;


                _db.SuppMessages.Add(message.SuppMessage);
                _db.SaveChanges();

                SuppMessage msg = _db.SuppMessages.FirstOrDefault(u => u.Email == message.SuppMessage.Email&&u.IsFirst==true);
                msg.IsFirst = false;

                SuppQuestions suppQuestions = new SuppQuestions();
                suppQuestions.Questions = message.Questions;
                suppQuestions.SuppMessageId = message.SuppMessage.Id;
                suppQuestions.Time = DateTime.Now;
                _db.SuppQuestions.Add(suppQuestions);
                _db.SuppMessages.Update(msg);
                _db.SaveChanges();
                return RedirectToAction("SendMsg");
            }
            else
            {
                return View(message);
            }
        }

        [HttpGet]
        public IActionResult ChatBox(int id, string role)
        {
            SuppMessage message = _db.SuppMessages.Include(u => u.SuppQuestions).Include(u=>u.SuppAnswers).Include(u=>u.User).FirstOrDefault(u => u.Id == id);
            

            ChatBoxVM chat = new ChatBoxVM();
            chat.SuppMessage = message;
            
            foreach(var userMsg in message.SuppQuestions)
            {
                AllMessage msg2 = new AllMessage();
                msg2.Msg = userMsg.Questions;
                msg2.Date = userMsg.Time;
                msg2.Name = message.User.Name;
                chat.Msg.Add(msg2);
            }
            foreach(var moderMsg in message.SuppAnswers)
            {
                chat.Msg.Add(new AllMessage
                {
                    Msg = moderMsg.Answer,
                    Date = moderMsg.Time,
                    Name = "support"
                });
            }

            chat.Msg = (from p in chat.Msg
                       orderby p.Date
                       select p).ToList();

            if(role=="user")
            {
                chat.IsUser = true;
            }
            else
            {
                chat.IsUser = false;
            }
            return View(chat);
        }

        public IActionResult AddMsg(ChatBoxVM box)
        {
            if (box.Message == null)
            {
                if(box.IsUser==true)
                    return RedirectToAction("ChatBox", "Support", new { id = box.SuppMessage.Id, role = "user" });
                else
                    return RedirectToAction("ChatBox", "Support", new { id = box.SuppMessage.Id, role = "support" });
            }
               
            //пользователь
            if(box.IsUser==true)
            {
                User user = _db.Users.Include(u => u.Role).Include(u => u.SuppMessages).FirstOrDefault(u => u.Id == box.SuppMessage.User.Id);

                SuppQuestions questions = new SuppQuestions();
                questions.Questions = box.Message;
                questions.SuppMessageId = box.SuppMessage.Id;
                questions.Time = DateTime.Now;

                SuppMessage suppMessage = _db.SuppMessages.FirstOrDefault(u=>u.Id==box.SuppMessage.Id);
                suppMessage.IsAnswer = false;

                _db.SuppMessages.Update(suppMessage);
                _db.SuppQuestions.Add(questions);
                _db.SaveChanges();

                return RedirectToAction("ChatBox", "Support", new { id = box.SuppMessage.Id, role="user" });
            }
            else
            {
                User user = _db.Users.Include(u => u.Role).Include(u => u.SuppMessages).FirstOrDefault(u => u.Id == box.SuppMessage.User.Id);

                SuppAnswer questions = new SuppAnswer();
                questions.Answer = box.Message;
                questions.SuppMessageId = box.SuppMessage.Id;
                questions.Time = DateTime.Now;


                SuppMessage suppMessage = _db.SuppMessages.FirstOrDefault(u => u.Id == box.SuppMessage.Id);
                suppMessage.IsAnswer = true;

                _db.SuppMessages.Update(suppMessage);
                _db.SuppAnswers.Add(questions);
                _db.SaveChanges();
                return RedirectToAction("ChatBox", "Support", new { id = box.SuppMessage.Id, role="support" });
            }
            
        }
        [Authorize(Roles = "admin,support")]
        public IActionResult ViewDetails(int id)
        {
            SuppMessage message = _db.SuppMessages.Include(u => u.SuppQuestions)
                                    .Include(u => u.SuppAnswers).Include(u => u.User).FirstOrDefault(u => u.Id == id);

            return View(message);
        }

        public IActionResult SendMsg()
        {
            return View();
        }

    }
}
