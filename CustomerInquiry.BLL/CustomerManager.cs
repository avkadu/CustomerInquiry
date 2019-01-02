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
            var Customer = db.Customers.Find(CustomerId);
            return Customer;
        }
    }
}
