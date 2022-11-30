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

/*namespace LetiSec.Controllers
{
    public class NewsController:Controller
    {
        private readonly LetiSecDB _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsController(LetiSecDB db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

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

        [HttpPost]
        public IActionResult Upsert()
        {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRoothPath = _webHostEnvironment.WebRootPath;

                if (productVM.Product.Id == 0)
                {
                    //create

                    string path = webRoothPath + WebConst.ImageProductPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(path, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVM.Product.Img = fileName + extension;

                    _db.Products.Add(productVM.Product);

                }
                else
                {
                    //update

                    var oldProduct = _db.Products.AsNoTracking().First(u => u.Id == productVM.Product.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRoothPath + WebConst.ImageNewsPath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, oldProduct.Img);

                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        productVM.Product.Img = fileName + extension;
                    }

                    _db.Products.Update(productVM.Product);

                }

                _db.SaveChanges();
                return RedirectToAction("CRUD");
            }
            else
            {

                return View(productVM);
            }


        }

        public IActionResult ProductDetails(int id)
        {

            ProductDetailsVM productDetailsVM = new ProductDetailsVM();

            productDetailsVM.Product = _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == id);

            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            if (_HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart) != null)
            {
                shoppingCarts = _HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }

            List<int> productId = shoppingCarts.Select(i => i.ProductId).ToList();

            if (productId.Contains(id))
                productDetailsVM.isContains = true;
            else
                productDetailsVM.isContains = false;

            ViewBag.ReturnUrl = Request.Path.ToString();

            return View(productDetailsVM);

        }

        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + WebConst.ImageProductPath;
            var oldFile = Path.Combine(upload, product.Img);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }


            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("CRUDProduct");
        }
    }
}
}
*/