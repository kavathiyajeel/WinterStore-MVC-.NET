using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{
    public class CartProduct
    {
        public int CartID { get; set; }
        public int CartCustomerID { get; set; }
        public int CartProductID { get; set; }
        public int CartQuantity { get; set; }
        public decimal CartPrice { get; set; }
        public string CartDateAdded { get; set; }
        public string CartDateModified { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
    }
}