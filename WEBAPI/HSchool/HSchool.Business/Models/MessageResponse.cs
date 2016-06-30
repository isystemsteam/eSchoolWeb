using HSchool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class MessageResponse
    {
        #region Ctors

        /// <summary>
        /// 
        /// </summary>
        public MessageResponse()
        {
            Status = ApiConstants.StatusSuccess;
            StatusCode = (int)HttpStatusCode.OK;
            Reason = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="statusCode"></param>
        /// <param name="reason"></param>
        public MessageResponse(string status = ApiConstants.StatusSuccess, int statusCode = (int)HttpStatusCode.OK, string reason = "")
        {
            Status = status;
            StatusCode = statusCode;
            Reason = reason;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32 StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Reason { get; set; }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageResponse<T> : MessageResponse
    {
        #region Ctors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="status"></param>
        /// <param name="statusCode"></param>
        /// <param name="reason"></param>
        public MessageResponse(T instance, string status = ApiConstants.StatusSuccess, int statusCode = (int)HttpStatusCode.OK, string reason = "")
            : base(status, statusCode, reason)
        {
            Instance = instance;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public T Instance { get; set; }
        #endregion
    }
}
