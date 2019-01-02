using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer = CustomerInquiry.DLL.Customer;

namespace CustomerInquiry.BLL
{
    public interface ICustomerManager
    {
        Customer GetCustomerData(int CustomerId, string Email);
    }
}
