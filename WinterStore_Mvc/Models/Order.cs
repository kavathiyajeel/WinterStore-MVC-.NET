using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{
    public class Order

    {
        public class CheckoutViewModel
        {
            public Customers Customer { get; set; }
            public Product Product { get; set; }

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09UAKUJ\JEEL;Initial Catalog=WinterStore;Integrated Security=True");
        [Key] public string OrderID { get; set; }

        public string OrderDate { get; set; }

        public decimal OrderTotal { get; set; }

        public int OrderCustomerID { get; set; }


        public string OrderShippingAddress { get; set; }

        public string OrderShippingCity { get; set;}

        public string OrderShippingState { get; set; }

        public string OrderShippingZip { get; set;}

        public string OrderPaymentMethod { get; set;}

        public string OrderPaymentStatus { get; set; }

        public string OrderTransactionID { get; set; }

        public string OrderStatus { get; set; }

        public string OrderModifiedDate { get; set; }


        public List<Order> getdata()
        {
           
            List<Order> lstCust = new List<Order>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Orders ", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstCust.Add(new Order
                {
                    OrderID = dr["OrderID"].ToString(),
                    OrderDate = dr["OrderDate"].ToString(),
                    OrderTotal = Convert.ToInt32(dr["OrderTotal"].ToString()),
                    OrderCustomerID = Convert.ToInt32(dr["OrderCustomerID"].ToString()),
                    OrderShippingAddress = dr["OrderShippingAddress"].ToString(),
                    OrderShippingCity = dr["OrderShippingCity"].ToString(),
                    OrderShippingState = dr["OrderShippingState"].ToString(),
                    OrderShippingZip = dr["OrderShippingZip"].ToString(),
                    OrderPaymentMethod = dr["OrderPaymentMethod"].ToString(),
                    OrderPaymentStatus = dr["OrderPaymentStatus"].ToString(),
                    OrderTransactionID = dr["OrderTransactionID"].ToString(),
                    OrderStatus = dr["OrderStatus"].ToString(),
                    OrderModifiedDate = dr["OrderModifiedDate"].ToString(),
                   
                });
            }
            return lstCust;
        }
        public List<Order> getSingleUserData(int id)
        {
            List<Order> lstord = new List<Order>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Orders where OrderCustomerID='"+id+"'", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstord.Add(new Order
                {
                    OrderID = dr["OrderID"].ToString(),
                    OrderDate = dr["OrderDate"].ToString(),
                    OrderTotal = Convert.ToInt32(dr["OrderTotal"].ToString()),
                    OrderCustomerID = Convert.ToInt32(dr["OrderCustomerID"].ToString()),
                    OrderShippingAddress = dr["OrderShippingAddress"].ToString(),
                    OrderShippingCity = dr["OrderShippingCity"].ToString(),
                    OrderShippingState = dr["OrderShippingState"].ToString(),
                    OrderShippingZip = dr["OrderShippingZip"].ToString(),
                    OrderPaymentMethod = dr["OrderPaymentMethod"].ToString(),
                    OrderPaymentStatus = dr["OrderPaymentStatus"].ToString(),
                    OrderTransactionID = dr["OrderTransactionID"].ToString(),
                    OrderStatus = dr["OrderStatus"].ToString(),
                    OrderModifiedDate = dr["OrderModifiedDate"].ToString(),

                });
            }
            return lstord;
        }
        public Order getSingleData(int id)
        {
            Order order = new Order();
            SqlCommand cmd = new SqlCommand("select * from Orders where OrderID=@OrderID", con);
            cmd.Parameters.AddWithValue("@OrderID", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            order.OrderID = dr["OrderID"].ToString();
            order.OrderDate = dr["OrderDate"].ToString();
            order.OrderTotal = Convert.ToInt32(dr["OrderTotal"].ToString());
            order.OrderCustomerID = Convert.ToInt32(dr["OrderCustomerID"].ToString());
 
            order.OrderShippingAddress = dr["OrderShippingAddress"].ToString();
            order.OrderShippingCity = dr["OrderShippingCity"].ToString();
            order.OrderShippingState = dr["OrderShippingState"].ToString();
            order.OrderShippingZip = dr["OrderShippingZip"].ToString();
            order.OrderPaymentMethod = dr["OrderPaymentMethod"].ToString();
            order.OrderPaymentStatus = dr["OrderPaymentStatus"].ToString();
            order.OrderTransactionID = dr["OrderTransactionID"].ToString();
            order.OrderStatus = dr["OrderStatus"].ToString();
            order.OrderModifiedDate = dr["OrderModifiedDate"].ToString();
            con.Close();
            return order;
        } 
     public bool Insert(int price,int cid,string add,string city,string state, string zip,string pmethod) {
            string payment = "";
            if (pmethod == "CashonDelivery")
            {
                payment = "pending";
            }
            else
            {
                payment = "Done";
            }
            string transactionid = GenerateCode();
            string orderid = "ORDX" + Generate();
            string query = "insert into Orders(OrderID,OrderDate,OrderTotal,OrderCustomerID,OrderItemID,OrderShippingAddress,OrderShippingCity,OrderShippingState,OrderShippingZip,OrderPaymentMethod,OrderPaymentStatus,OrderTransactionID,OrderStatus) values (@oid,@odate,@ototal,@ocid,@oitid,@oadd,@ocity,@ostate,@opincode,@opmethod,@opstatus,@otid,@ostatus)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@oid", orderid);
            cmd.Parameters.AddWithValue("@odate", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@ototal", price );
            cmd.Parameters.AddWithValue("@ocid",cid);
            cmd.Parameters.AddWithValue("@oitid", transactionid);
            cmd.Parameters.AddWithValue("@oadd",add);
            cmd.Parameters.AddWithValue("@ocity", city);
            cmd.Parameters.AddWithValue("@ostate", state);
            cmd.Parameters.AddWithValue("@opincode",zip);
            cmd.Parameters.AddWithValue("@opmethod", pmethod);
            cmd.Parameters.AddWithValue("@opstatus", payment);
            cmd.Parameters.AddWithValue("@otid", transactionid);
            cmd.Parameters.AddWithValue("@ostatus", "Placed");
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;

        }
        private string Generate()
        {
            const string characters = "0123456789";
            var code = new char[4];
            var random = new Random();

            for (int i = 0; i < 4; i++)
            {
                code[i] = characters[random.Next(characters.Length)];
            }

            return new string(code);
        }

        public string GenerateCode()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var code = new char[10];
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                code[i] = characters[random.Next(characters.Length)];
            }

            return new string(code);
        }


    }
}