using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
       public List<Transaction> Transactions { get; set; }
    }
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string  TransactionDateTime { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}