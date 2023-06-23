using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{
    public class CheckoutViewModel

    {
        public Customers Customer { get; set; }
        public Product Product { get; set; }
        public PaymentMethod paymentMethod { get; set; }    
        public enum PaymentMethod
        {
           CashonDelivery,
                        Paytm,
                        Gpay,
                        PhonePay,
                        OtherUpi,
                        NetBanking,
                        Credit_DebitCard,
                        EMI
        }
    }
}