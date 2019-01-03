using CustomerInquiry.BLL;
using CustomerInquiry.Controllers;
using CustomerInquiry.DLL;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using CustomerInquiry.ErrorHandlers;
using System.Web.UI.WebControls;

namespace CustomerInquiry.Tests
{
    [TestFixture]
    public class CustomerControllerFixture
    {
        private ICustomerManager customerQuery;
        private CustomerController controller;

        [SetUp]
        public void Setup()
        {

            customerQuery = MockRepository.GenerateMock<ICustomerManager>();
            new CustomerController()._customerManager = this.customerQuery;
            controller = new CustomerController()
            {
                _customerManager = this.customerQuery
            };

        }


        [Test]
        public void GetCustomer_Valid_Call()
        {
            var customerId = 1;
            var email = "avp@gmail.com";
            customerQuery.Expect(x => x.GetCustomerData(Arg<int>.Is.Equal(customerId),Arg<string>.Is.Equal(email))).Return(new Customer
            {
                CustomerID = 1,
                CustomerName = "Dip",
                ContactEmail = "avp@gmail.com",
                MobileNo = "8149911140",
                Transactions = {}
            });
            var result = controller.GetCustomer(customerId,email);

            Assert.That(result, Is.Not.Null);
            customerQuery.VerifyAllExpectations();
        }

        [Test]
        public void GetWUBSCustomerById_NotFound()
        {
            var customerId = 0;
            string email = null;
            customerQuery.Expect(x => x.GetCustomerData(Arg<int>.Is.Equal(customerId), Arg<string>.Is.Equal(email))).Return(new Customer());

            var result = controller.GetCustomer(customerId, email);
            var controllerResponse = (ResponseMessageResult)controller.GetCustomer(customerId, email);
            var content =controllerResponse.Response.Content;

            Assert.AreEqual(controllerResponse.Response.StatusCode, HttpStatusCode.BadRequest);
            //Assert.That(content.Headers, Contains.Item((int)ErrorCode.NoInquiry));

        }

 
    }
}
