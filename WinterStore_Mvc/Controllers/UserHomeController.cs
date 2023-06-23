using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        Product proObj = new Product();
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult Men()
        {
            proObj = new Product();
            List<Product> products = proObj.getData_Men();
            return View(products);
        }

        public ActionResult Women()
        {
            proObj = new Product();
            List<Product> products = proObj.getData_Women();
            return View(products);
        }

        public ActionResult Kids()
        {
            proObj = new Product();
            List<Product> products = proObj.getData_Kids();
            return View(products);
        }


    }
}
