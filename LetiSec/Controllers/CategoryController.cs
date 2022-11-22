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
    public class CategoryController:Controller
    {
        private readonly LetiSecDB _db;

        public CategoryController(LetiSecDB db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult ViewCategory()
        {
            IEnumerable<Category> categories = _db.Categories;
                                                
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Category category = new Category();

            return View(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                
                _db.Categories.Add(category);
                _db.SaveChanges();

                return RedirectToAction("ViewCategory");
            }
            else
                return View(category);
            
        }
        
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            else
            {
                //ошибка
            }

            return RedirectToAction("ViewCategory");
        }
       
        

    }
}
