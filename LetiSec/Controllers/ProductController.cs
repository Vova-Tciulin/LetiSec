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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LetiSec.Controllers
{
    public class ProductController:Controller
    {
        private readonly LetiSecDB _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(LetiSecDB db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        public IActionResult CRUD()
        {
            IEnumerable<Product> products = _db.Products.Include(u=>u.Category);

            return View(products);
        }

        [HttpGet]
        public IActionResult ViewProduct()
        {
            ProductVM productVM = new ProductVM()
            {
                Products = _db.Products.Include(u => u.Category),
                Categories = _db.Categories
            };

           

            return View(productVM);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            CRUDProductVM crudProductVM = new CRUDProductVM()
            {
                Categories =_db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                Product = new Product()
            };
            if(id==null)
            {
                //create
                return View(crudProductVM);
            }
            else
            {
                //update
                crudProductVM.Product = _db.Products.Find(id);

                return View(crudProductVM);
            }
 
        }

        [HttpPost]
        public IActionResult Upsert(CRUDProductVM productVM)
        {
            
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRoothPath = _webHostEnvironment.WebRootPath;

                if (productVM.Product.Id == null)
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
                        string upload = webRoothPath + WebConst.ImageProductPath;
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
         
            Product? product = _db.Products.Include(u=>u.Category).FirstOrDefault(u=>u.Id==id);

            if (product == null)
                return NotFound();

            return View(product);

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
