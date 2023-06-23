using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class OrderController : Controller

    {
        Customers custObj = new Customers();
        Product prodObj = new Product();

        Order orderObj = new Order();
        // GET: Customer
        public ActionResult Index()
        {

            orderObj = new Order();
            List<Order> orders = orderObj.getdata();
            return View(orders);
           
        }

        public ActionResult MyOrder(int id)
        {

            orderObj = new Order();
            List<Order> orders = orderObj.getSingleUserData(id);
            return View(orders);

        }
        public ActionResult MyOrderDetails()
        {
            //Order order = orderObj
            return View();


        }
        public ActionResult BuyNow()
        {

            //Order order = orderObj.getData(id);
            return View();
        }

        public ActionResult OrderComplete() 
        {

            //orderObj = new Order();
            //List<Order> orders = orderObj.getData();
            return View();

        }
        [HttpGet]
        public ActionResult Checkout(int cid, int pid)
        {
            var viewModel = new CheckoutViewModel
            {
                Customer = custObj.getData(pid),
                Product = prodObj.getData(pid),
            };

            return View(viewModel);
        } 
        [HttpPost]
        public ActionResult BuyNow(CheckoutViewModel viewModel)
        {
            orderObj = new Order();
            bool res = orderObj.Insert(viewModel.Product.pprice,viewModel.Customer.CustomerID, viewModel.Customer.CustomerAddress, viewModel.Customer.CustomerCity, viewModel.Customer.CustomerState, viewModel.Customer.CustomerZip,viewModel.paymentMethod.ToString());
            return RedirectToAction("SuccessOrder", "Cart");
        }

    }
}