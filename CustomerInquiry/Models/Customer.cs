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
        public int? MobileNo { get; set; }
       public List<Transaction> Transactions { get; set; }
    }
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime? TransactionDateTime { get; set; }
        public decimal? Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}