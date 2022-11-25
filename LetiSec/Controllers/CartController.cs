using Microsoft.AspNetCore.Identity;
using LetiSec.PassHashes;
using Microsoft.AspNetCore.Authorization;
using LetiSec.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Mvc;
using LetiSec.Models;
using LetiSec.Utility;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LetiSec.Controllers
{
    public class CartController:Controller
    {
        private readonly  LetiSecDB _db;
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public CartController(LetiSecDB db, IHttpContextAccessor HttpContextAccessor)
        {
            _db = db;
            _HttpContextAccessor = HttpContextAccessor;
        }

        public IActionResult AddProduct(int id)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ProductId = id;
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (_HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart) != null)
            {
                shoppingCarts = _HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }
            shoppingCarts.Add(cart);
            _HttpContextAccessor.HttpContext.Session.Set<List<ShoppingCart>>(WebConst.SessionCart, shoppingCarts);

            //сделать возврат на ту страницу, с которой был сделан переход
            return RedirectToAction("ProductDetails", "Product", new {id=id});
        }

        public IActionResult ViewCart(int?id)
        {
            
            
            //все id товаров
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            if (_HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart) != null)
            {
                shoppingCarts = _HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }
            List<int>productId= shoppingCarts.Select(i => i.ProductId).ToList();

            //получаем товар по id
            IEnumerable<Product> productsDb = _db.Products.Where(u => productId.Contains(u.Id));
            ViewBag.ReturnUrl = Request.Path.ToString();

            return View(productsDb);

        }

        public IActionResult RemoveProduct(string path)
        {
            string[] path1 = path.Split("/");

            int id = Int32.Parse(path1[3]);

            ShoppingCart cart = new ShoppingCart();
            cart.ProductId = id;
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            if (_HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart) != null)
            {
                shoppingCarts = _HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }

            List<ShoppingCart> shoppingCarts1 = (from p in shoppingCarts
                                                 where p.ProductId != id
                                                 select p).ToList();
            _HttpContextAccessor.HttpContext.Session.Set<List<ShoppingCart>>(WebConst.SessionCart, shoppingCarts1);

            string action = path1[2];
            string controller = path1[1];

            return RedirectToAction(action, controller, new {id=id});
        }

        [Authorize]
        public IActionResult BuyProduct()
        {
            
            //все id товаров
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            if (_HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart) != null)
            {
                shoppingCarts = _HttpContextAccessor.HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }
            List<int> productId = shoppingCarts.Select(i => i.ProductId).ToList();

            //получаем товар по id
            IEnumerable<Product> productsDb = _db.Products.Where(u => productId.Contains(u.Id));
     
            Order order = new Order();

            var userName = HttpContext.User.Identity.Name;
            User user = _db.Users.FirstOrDefault(u => u.Email == userName);

            order.UserId = user.Id;
            foreach(var product in productsDb)
            {
                order.Products.Add(product);
            }

            _HttpContextAccessor.HttpContext.Session.Clear();
            _db.Orders.Add(order);
            _db.SaveChanges();

            return RedirectToAction("Home","Home");
        }
        



    }
}
