using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerInquiry.DLL;
using System.Web.Http.Routing;
using CustomerInquiry.ErrorHandlers;
using CustomerInquiry.Utilities;
using CustomerInquiry.BLL;
using CustomerInquiry.Models;

namespace CustomerInquiry.Controllers
{
    public class CustomerController : ApiController
    {
        public  ICustomerManager _customerManager;
        //GetCustomer
        [HttpGet]
        public IHttpActionResult GetCustomer(int customerId =0,string email =null)
        {
            var urlHelper = new UrlHelper(Request);
            _customerManager = new CustomerManager();
            if (email == null && customerId==0)
                return ErrorGenerator.GenerateErrorResponse(Request, HttpStatusCode.BadRequest, ErrorCode.NoInquiry);

            if(Helper.IsValidEmail(email))
                return ErrorGenerator.GenerateErrorResponse(Request, HttpStatusCode.BadRequest, ErrorCode.InvalidEmail);
           
            var customer = _customerManager.GetCustomerData(customerId, email);

            if(customer==null)
                return ErrorGenerator.GenerateErrorResponse(Request, HttpStatusCode.NotFound, ErrorCode.NotFound);

            return Ok(Mapper.ToCustomerModel(customer));
        }
    }
}
