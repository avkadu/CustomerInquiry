using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerInquiry.DLL;
using System.Web.Http.Routing;
using CustomerInquiry.ErrorHandlers;
using CustomerInquiry.BLL;
using CustomerInquiry.Models;

namespace CustomerInquiry.Controllers
{
    public class CustomerController : ApiController
    {
        private  ICustomerManager _customerManager;

        [HttpGet]
        public IHttpActionResult GetCustomer(int customerId =0,string email =null)
        {
            var urlHelper = new UrlHelper(Request);
            _customerManager = new CustomerManager();
            if (email == null && customerId==0)
                return ErrorGenerator.GenerateErrorResponse(Request, HttpStatusCode.BadRequest, ErrorCode.NoInquiry);
            var customer = _customerManager.GetCustomerData(customerId, email);
         
            return Ok(Mapper.ToCustomerModel(customer));
        }
    }
}
