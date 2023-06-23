using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{
    public class ViewOrder
    {
        public Product Product { get; set; }
        public Customers customer { get; set; }
        public Order orderorder { get; set; }   
    }
}