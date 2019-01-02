using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace CustomerInquiry.ErrorHandlers
{
    public static class ErrorGenerator
    {
        

        public static ResponseMessageResult GenerateErrorResponse(HttpRequestMessage request, HttpStatusCode httpStatusCode, ErrorCode errorCode)
        {
            return GenerateErrorResponse(request, httpStatusCode, errorCode, null);
        }

        public static ResponseMessageResult GenerateErrorResponse(HttpRequestMessage request, HttpStatusCode httpStatusCode, ErrorCode errorCode, string message)
        {

            var errorList = new List<Error>
            {
                CreateError((int) errorCode, message == null ? errorCode.DescriptionOfValue() : message)
            };

            var responseMsg = request.CreateResponse(httpStatusCode, errorList);

            return new ResponseMessageResult(responseMsg);
        }
        public static string DescriptionOfValue<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

   
        public static Error CreateError(int errorcode, string message)
        {
            var error = new Error
            {
                Code = errorcode,
                Message =  errorcode == 1000 ? ErrorCode.UnknownError.DescriptionOfValue() : message
            };

            return error;
        }

       
    }
}