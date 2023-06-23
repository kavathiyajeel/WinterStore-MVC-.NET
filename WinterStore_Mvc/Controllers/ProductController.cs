using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class ProductController : Controller
    {
        Product prodObj = new Product();
        // GET: Product
        public ActionResult Index()
        {
            prodObj = new Product();
            List<Product> products = prodObj.getData();
            return View(products);
        }


        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            prodObj = new Product();

            res = prodObj.Insert(product);
            if (res)
            {
                TempData["msg"] = "Added successfully";
            }
            //}
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = prodObj.getData(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            bool res;
            prodObj = new Product();
            res = prodObj.Update(product);
            if (res) { TempData["msg"] = "Updated successfully"; } else { TempData["msg"] = "Not Updated. something went wrong..!!"; }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product product = prodObj.getData(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            bool res;
            prodObj = new Product();
            res = prodObj.delete(product);
            if (res) { TempData["msg"] = "Deleted successfully"; }
            else { TempData["msg"] = "Not Deleted. something went wrong..!!"; }
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            prodObj = new Product();
            Product products = prodObj.getData(id);
            return View(products);
        }
       
    }
}