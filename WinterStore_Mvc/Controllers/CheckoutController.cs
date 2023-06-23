using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class CheckoutController : Controller
    {
        Customers custObj = new Customers();
        Product prodObj = new Product();
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Checkout(int cid, int pid)
        {
            var viewModel = new CheckoutViewModel
            {
                Customer = custObj.getData(cid),
                Product = prodObj.getData(pid),
            };

            return View(viewModel);
        }

    }
}