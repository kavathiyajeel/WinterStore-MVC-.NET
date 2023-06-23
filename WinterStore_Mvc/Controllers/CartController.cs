using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        Customers custObj = new Customers();
        Product prodObj = new Product();
        Cart cartObj = new Cart();

        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09UAKUJ\JEEL;Initial Catalog=WinterStore;Integrated Security=True");

            List<CartProduct> cartProducts = new List<CartProduct>();

            string query = "SELECT c.*, p.pname, p.pimage, p.pprice FROM Cart c INNER JOIN Products p ON c.CartProductID = p.pid WHERE c.CartCustomerID = @customerId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@customerId", (int)Session["userid"]);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CartProduct cartProduct = new CartProduct();
                cartProduct.CartID = Convert.ToInt32(reader["CartID"]);
                cartProduct.CartCustomerID = Convert.ToInt32(reader["CartCustomerID"]);
                cartProduct.CartProductID = Convert.ToInt32(reader["CartProductID"]);
                cartProduct.CartQuantity = Convert.ToInt32(reader["CartQuantity"]);
                cartProduct.CartPrice = Convert.ToDecimal(reader["CartPrice"]);
                cartProduct.CartDateAdded = Convert.ToString(reader["CartDateAdded"]);
                cartProduct.CartDateModified = Convert.ToString(reader["CartDateModified"]);
                cartProduct.ProductName = Convert.ToString(reader["pname"]);
                cartProduct.ProductImage = Convert.ToString(reader["pimage"]);
                cartProduct.ProductPrice = Convert.ToDecimal(reader["pprice"]);
                cartProducts.Add(cartProduct);
            }
            reader.Close();

            return View(cartProducts);
        }

        public ActionResult SuccessOrder()
        {
            return View();
        }
        public ActionResult Deleteitem(int id)
        {
            bool res;
            res = cartObj.Delete(id);

            return RedirectToAction("Index");
        }
        public ActionResult AddtoCart(int cid, int pid)
        {
            var pdata = prodObj.getData(pid);
            Cart data = new Cart
            {
                CartCustomerID = cid,
                CartDateAdded = DateTime.Now.ToShortDateString(),
                CartProductID = pid,
                CartPrice = pdata.pprice,
                CartQuantity = 1,

            };
            bool res;
            res = cartObj.Insert(data);
            return RedirectToAction("Index");
        }

    }
}