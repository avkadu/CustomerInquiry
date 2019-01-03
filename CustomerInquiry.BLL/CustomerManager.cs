using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.DLL;
using Customer = CustomerInquiry.DLL.Customer;

namespace CustomerInquiry.BLL
{
    public class CustomerManager : ICustomerManager
    {
        private CustomerInquiryEntities db = new CustomerInquiryEntities();
        public Customer GetCustomerData(int CustomerId, string Email)
        {
            var customer = new Customer();
            try
            {
                customer = db.Customers.Where(x => x.CustomerID == CustomerId & x.ContactEmail == Email).FirstOrDefault();
                customer.Transactions = customer.Transactions.OrderBy(x => x.TransactionDateTime).Take(5).ToList();
            }
            catch (Exception e)
            {
                customer = null;
            }
            
            return customer;
        }
    }
}
