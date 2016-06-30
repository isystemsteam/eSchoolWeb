using HSchool.Data.Models;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Helper
{
    public static class UserAuthentication
    {

        public static string CreatePassword()
        {
            return string.Empty;
        }

        public static bool ValidateUserCredential(UserSecurity userSecurity, UserCredential credential)
        {
            LogHelper.Info(string.Format("UserRepository.ValidateUser - Begin"));
            return true;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="randomString"></param>
        /// <returns></returns>
        private static string EncryptString(string value, string randomString)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(string.Format("{0}{1}", value, randomString));
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(randomString));
            hashmd5.Clear();
            return Convert.ToBase64String(keyArray, 0, keyArray.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string DecryptString(string value)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(value);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(string.Empty));
            //release any resource held by the MD5CryptoServiceProvider

            hashmd5.Clear();
            return UTF8Encoding.UTF8.GetString(toEncryptArray);
        }
    }
}
