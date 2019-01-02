using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    public static class Mapper
    {
        public static Customer ToCustomerModel(CustomerInquiry.DLL.Customer response)
        {

            var transactionList = new List<Transaction>();
            if (response.Transactions.Count > 0)
            {
                foreach (var result in response.Transactions)
                {
                    var transaction = new Transaction
                    {
                        TransactionID = result.TransactionID,
                        TransactionDateTime = result.TransactionDateTime,
                        Amount = result.Amount,
                        CurrencyCode = result.CurrencyCode,
                        Status = result.Status
                    };
                    transactionList.Add(transaction);
                }
            }
            return new Customer()
            {
                CustomerID = response.CustomerID,
                CustomerName = response.CustomerName,
                ContactEmail = response.ContactEmail,
                MobileNo = response.MobileNo,
                Transactions = response.Transactions.Count==0? new List<Transaction>() : transactionList
            };
        }
    }
}