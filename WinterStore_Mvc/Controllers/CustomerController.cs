using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class CustomerController : Controller

    {
        Customers custObj = new Customers();
        // GET: Customer
        public ActionResult Index()
        {
            
            custObj = new Customers();
            List<Customers> customer = custObj.getData();  
            return View(customer);
        }
   
        public ActionResult AddCustomer()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult AddCustomer(Customers customer)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            custObj = new Customers();

            res = custObj.Insert(customer);
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
        [HttpGet] public ActionResult EditCustomer(int id) {
            Customers customer = custObj.getData(id);
            return View(customer);  
        }  
        [HttpGet] public ActionResult Myprofile(int id) {
            Customers customer = custObj.getData(id);
            return View(customer);  
        }
        [HttpGet] public ActionResult UpdateProfile(int id) {
            Customers customer = custObj.getData(id);
            return View(customer);  
        }
        [HttpPost] public ActionResult UpdateProfile(Customers customer) {
            bool res ;
            custObj = new Customers();  
            res = custObj.Update(customer);
            return RedirectToAction("Myprofile", new { @id = (int)Session["userid"] });
        }
        
        [HttpPost] public ActionResult EditCustomer(Customers customer) {
            bool res ;
            custObj = new Customers();  
            res = custObj.Update(customer);
            if (res) { TempData["msg"] = "Updated successfully"; }  else { TempData["msg"] = "Not Updated. something went wrong..!!"; }
            return View();
        }


        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            Customers customer = custObj.getData(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(Customers customer)
        {
            bool res;
             custObj = new Customers();
            res = custObj.delete(customer);
            if (res) { TempData["msg"] = "Deleted successfully"; } 
            else { TempData["msg"] = "Not Deleted. something went wrong..!!"; }
            return View();
        }
       
                }

}