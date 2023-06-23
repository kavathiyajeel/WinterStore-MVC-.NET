using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Customers custObj = new Customers();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customers customer)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            custObj = new Customers();

            res = custObj.Insert(customer);
            if (res)
            {
                TempData["msg"] = "Registered successfully";
            }
            //}
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }
            return RedirectToAction("Index");
        } 
        [HttpPost]
        public ActionResult Login(Customers customer)
        {
        
            //if (ModelState.IsValid)
            //{
            custObj = new Customers();

            var res = custObj.Login(customer.CustomerEmail, customer.CustomerPassword,1);
            if (res.Item1 == "user") {
                Session["username"] = (string)res.Item2;
                Session["userid"] = (int)res.Item3;
           
                return RedirectToAction("Index", "UserHome");

            }
            else if(res.Item1 == "admin") {
                Session["username"] = (string)res.Item2;

           
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["msg"] = "Incorrect Password";

                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public ActionResult Logout() {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index"); }
    }
}