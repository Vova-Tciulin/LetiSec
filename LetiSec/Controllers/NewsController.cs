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
using LetiSec.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LetiSec.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly LetiSecDB _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsController(LetiSecDB db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        // [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public IActionResult CRUD()
        {
            IEnumerable<News> news = _db.News;

            return View(news);
        }

        [HttpGet]
        public IActionResult ViewNews()
        {
            IEnumerable<News> news = _db.News;

            return View(news);
        }
        // [Authorize(Roles = "admin,moderator")]
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            News news = new News();

            if (id == null)
            {
                //create
                return View(news);
            }
            else
            {
                //update
                news = _db.News.Find(id);

                return View(news);
            }

        }
        // [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public IActionResult Upsert(News news)
        {
            

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRoothPath = _webHostEnvironment.WebRootPath;

                if (news.Id == 0)
                {
                    //create
                    if (files.Count == 0)
                        return View(news);
                    string path = webRoothPath + WebConst.ImageNewsPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(path, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    news.Img = fileName + extension;
                    news.Date= DateTime.Now;
                    _db.News.Add(news);

                }
                else
                {
                    //update

                    var oldNews = _db.News.AsNoTracking().First(u => u.Id == news.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRoothPath + WebConst.ImageNewsPath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, oldNews.Img);

                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        news.Img = fileName + extension;
                    }
                    else
                    {
                        news.Img = oldNews.Img;
                    }
                    _db.News.Update(news);

                }

                _db.SaveChanges();
                return RedirectToAction("CRUD");
            }
            else
            {

                return View(news);
            }


        }
        public IActionResult NewsDetails(int id)
        {

            News news = _db.News.FirstOrDefault(u=>u.Id==id);
            return View(news);
        }
        // [Authorize(Roles = "admin,moderator")]
        public IActionResult Delete(int id)
        {
            var news = _db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + WebConst.ImageNewsPath;
            var oldFile = Path.Combine(upload, news.Img);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }


            _db.News.Remove(news);
            _db.SaveChanges();
            return RedirectToAction("CRUD");
        }
    }
}

