using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CustomerInquiry.ErrorHandlers
{
    public enum ErrorCode
    {
        [Description("There was a problem during the request")]
        UnknownError = 1000,
        [Description("No inquiry criteria")]
        NoInquiry = 1001,

        [Description("Invalid Customer ID")]
        InvalidCustomerID = 1002,

        [Description("Invalid Email")]
        InvalidEmail = 1003,

        [Description("Not Found")]
        NotFound = 1004,
    }
}