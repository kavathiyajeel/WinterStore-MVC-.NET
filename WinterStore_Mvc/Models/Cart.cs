using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WinterStore_Mvc.Models
{
    public class Cart
    {

        [Key] public int CartID { get; set; }

        public int CartCustomerID { get; set; }

        public int CartProductID { get;set; }

        public int CartQuantity { get; set; }

        public decimal CartPrice { get; set; }

        public string CartDateAdded { get; set; }

        public string CartDateModified { get; set; }
        public virtual Product Product { get; set; }
        public bool Insert(Cart cart)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09UAKUJ\JEEL;Initial Catalog=WinterStore;Integrated Security=True");

            con.Open();
            string query = "Insert into Cart (CartCustomerID,CartProductID,CartQuantity,CartPrice,CartDateAdded,CartDateModified) values (@cid,@pid,@quantity,@price,@date,@datem)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@cid", cart.CartCustomerID);
            cmd.Parameters.AddWithValue("@pid", cart.CartProductID);
            cmd.Parameters.AddWithValue("@quantity", 1);
            cmd.Parameters.AddWithValue("@price", cart.CartPrice);
            cmd.Parameters.AddWithValue("@date", DateTime.Today.ToShortDateString());
            cmd.Parameters.AddWithValue("@datem", DateTime.Today.ToShortDateString());
            int i = cmd.ExecuteNonQuery();
            if (i >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Cart> GetCartItems(int customerId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRAV\NIRAV;Initial Catalog=Winterstore;Integrated Security=True");
            con.Open();

            string query = "SELECT * FROM Cart WHERE CartCustomerID = @customerId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@customerId", customerId);

            List<Cart> cartItems = new List<Cart>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cart cartItem = new Cart()
                    {
                        CartID = Convert.ToInt32(reader["CartID"]),
                        CartCustomerID = Convert.ToInt32(reader["CartCustomerID"]),
                        CartProductID = Convert.ToInt32(reader["CartProductID"]),
                        CartQuantity = Convert.ToInt32(reader["CartQuantity"]),
                        CartPrice = Convert.ToDecimal(reader["CartPrice"]),
                        CartDateAdded = Convert.ToString(reader["CartDateAdded"]),
                        CartDateModified = Convert.ToString(reader["CartDateModified"])
                    };

                    cartItems.Add(cartItem);
                }
            }

            return cartItems;
        }
        public bool Delete(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NIRAV\NIRAV;Initial Catalog=Winterstore;Integrated Security=True");

            con.Open();
            string query = "Delete from Cart where CartID = '"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            if(i>=0) { return true; }
            else
            {
                return false;
            }
        }

    }


}