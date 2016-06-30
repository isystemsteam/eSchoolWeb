using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Response
    {
        private bool _isSuccess;
        private string _message;
        private int _statusCode;



        public Response()
        {
        }

        public Response(bool isSuccess, string message, int statusCode)
        {
            _isSuccess = isSuccess;
            _message = message;
            _statusCode = statusCode;
        }

        public bool IsSuccess
        {
            get
            {
                return _isSuccess;
            }
            set
            {
                _isSuccess = value;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        public int StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }
    }
}
