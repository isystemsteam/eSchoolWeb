using HSchool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get { return _statusCode != 0 ? _statusCode : HttpStatusCode.OK; }
            set { _statusCode = value; }
        }

        private HttpStatusCode _statusCode;

        /// <summary>
        /// 
        /// </summary>
        public string StatusText
        {
            get { return string.IsNullOrWhiteSpace(_statusText) ? ApiConstants.StatusSuccess : _statusText; }
            set { _statusText = value; }
        }

        private string _statusText;

        /// <summary>
        /// 
        /// </summary>
        public string Reason { get; set; }
    }
}
