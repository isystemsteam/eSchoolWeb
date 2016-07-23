using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Common
{
    public static class CommonHelper
    {
        /// <summary>
        /// to get web config values
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="name">app settings name</param>
        /// <returns>returns configvalue with type</returns>
        public static T GetWebConfigValue<T>(string name)
        {
            return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[name])
                       ? default(T)
                       : (T)Convert.ChangeType(ConfigurationManager.AppSettings[name], typeof(T));
        }

        public static List<SelectListItem> ConvertEnumToListItem<T>()
        {
            var listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                listItem.Add(new SelectListItem { Value = Convert.ToString((int)(item)), Text = Enum.GetName(typeof(T), item) });
            }
            return listItem;
        }

        public static List<SelectListItem> ConvertEnumToListItem<T>(string defaultValue)
        {
            var listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = defaultValue, Value = "0" });
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                listItem.Add(new SelectListItem { Value = Convert.ToString((int)(item)), Text = Enum.GetName(typeof(T), item) });
            }
            return listItem;
        }

        public static List<SelectListItem> ConvertListToSelectList<T>(List<T> source, string defaultValue, string valueProp, string textProp)
        {
            var listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = defaultValue, Value = "0" });
            foreach (var item in source)
            {
                PropertyInfo textProperty = item.GetType().GetProperty(textProp);
                PropertyInfo valueProperty = item.GetType().GetProperty(valueProp);
                listItem.Add(new SelectListItem { Value = Convert.ToString(valueProperty.GetValue(item, null)), Text = (string)textProperty.GetValue(item, null) });
            }
            return listItem;
        }

        public static SelectListItem GetFirstListItem()
        {
            return new SelectListItem { Text = "Select", Value = "0" };
        }

        public static SelectListItem GetListItem(string value)
        {
            return new SelectListItem { Text = value, Value = "0" };
        }

        /// <summary>
        /// to convert timestamp to datetime
        /// </summary>
        /// <param name="timestamp">timestamp value</param>
        /// <param name="timeOffset">time offset in minutes </param>
        /// <param name="cultureInfo">logged in user culture info </param>
        /// <returns>returns datetime as string</returns>
        public static string ConvertTimestampToDateTime(Double timestamp, Double timeOffset, string cultureInfo)
        {
            LogHelper.Info(String.Format("CommonHelper.ConvertTimestampToDateTime - Begin. TimeStamp:{0}", timestamp));
            // First make a System.DateTime equivalent to the UNIX Epoch.
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            timeOffset = timeOffset * -1.0;
            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(timestamp).AddMinutes(timeOffset);
            // The dateTime now contains the right date/time so to format the string,
            // use the standard formatting methods of the DateTime object.
            var formattedDate = String.Format("{0} {1}", dateTime.ToString(ApiConstants.DateFormat, CultureInfo.CreateSpecificCulture(cultureInfo)), dateTime.ToString(ApiConstants.TimeFormat));
            LogHelper.Info(String.Format("CommonHelper.ConvertTimestampToDateTime - End. TimeStamp:{0}", timestamp));
            return formattedDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int ConvertDateTimeToTimestamp(DateTime dateTime)
        {
            LogHelper.Info(String.Format("CommonHelper.ConvertDateTimeToTimestamp - Begin. DateTime:{0}", dateTime));
            var unixTimestamp = (Int32)(dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            LogHelper.Info(String.Format("CommonHelper.ConvertDateTimeToTimestamp - End. TimeStamp:{0}", unixTimestamp));
            return unixTimestamp;
        }

        /// <summary>
        /// to format message string
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string FormatMessageString(string message)
        {
            LogHelper.Info(string.Format("CommonHelper.FormatMessageString - Begin. Message:{0}", message));
            if (!String.IsNullOrWhiteSpace(message))
            {
                if (message.Contains(ApiConstants.LessThanStr))
                {
                    message = message.Replace(ApiConstants.LessThanStr, ApiConstants.LessThanReplace);
                }

                if (message.Contains(ApiConstants.GreaterThanStr))
                {
                    message = message.Replace(ApiConstants.GreaterThanStr, ApiConstants.GreaterThanReplace);
                }

                if (message.Contains(ApiConstants.GreaterThanSymbol1))
                {
                    message = message.Replace(ApiConstants.GreaterThanSymbol1, ApiConstants.GreaterThanReplace);
                }

                if (message.Contains(ApiConstants.LessThanSymbol1))
                {
                    message = message.Replace(ApiConstants.LessThanSymbol1, ApiConstants.LessThanReplace);
                }

                if (message.Contains(ApiConstants.ApostropheStr))
                {
                    message = message.Replace(ApiConstants.ApostropheStr, ApiConstants.ApostropheSymbol);
                }
                LogHelper.Info(string.Format("CommonHelper.FormatMessageString - End. FormattedMessage:{0}", message));
                return message;
            }
            return String.Empty;
        }

        /// <summary>
        /// to format get job error message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string FormatGetJobErrorMessage(string message)
        {
            LogHelper.Info(string.Format("CommonHelper.FormatGetJobErrorMessage - Begin. Message:{0}", message));
            if (!String.IsNullOrWhiteSpace(message))
            {
                string validMessage;
                var formatMessage = FormatMessageString(message);
                var spilltedText = formatMessage.Split(ApiConstants.CharColon);
                if (spilltedText.Length > 0 && spilltedText.Length == 4)
                {
                    validMessage = spilltedText[3];
                }
                else
                {
                    var arrText = new[] { ApiConstants.StrColonSpace };
                    var splittedTextTwo = formatMessage.Split(arrText, StringSplitOptions.None);
                    validMessage = splittedTextTwo.Length == 2 ? splittedTextTwo[1] : message;
                }
                LogHelper.Info(string.Format("CommonHelper.FormatGetJobErrorMessage - End. FormattedMessage:{0}", validMessage));
                return validMessage;
            }
            return String.Empty;
        }

        /// <summary>
        /// to get mime format
        /// </summary>
        /// <param name="fileType">file type</param>
        /// <returns>returns mime type</returns>
        public static string GetMimeFormatType(string fileType)
        {
            LogHelper.Info(String.Format("CommonHelper.GetFormatType - Begin. FileType:{0}", fileType));
            string formatType;
            var arrayImageTypes = ApiConstants.ImageFileTypes.Split(ApiConstants.CharCommaSeparator).ToList();
            var arrayApplicationTypes = ApiConstants.ApplicationFileTypes.Split(ApiConstants.CharCommaSeparator).ToList();
            if (arrayImageTypes.IndexOf(fileType) != -1)
            {
                formatType = String.Format(ApiConstants.FormatBase64ImageMimeType,
                                           fileType.Substring(1, fileType.Length - 1).ToLowerInvariant());
            }
            else if (arrayApplicationTypes.IndexOf(fileType) != -1)
            {
                formatType = String.Format(ApiConstants.FormatBase64ApplicationMimeType,
                                           fileType.Substring(1, fileType.Length - 1).ToLowerInvariant());
            }
            else
            {
                formatType = String.Format(ApiConstants.FormatBase64ApplicationMimeType, ApiConstants.TextUnknown);
            }
            LogHelper.Info(String.Format("CommonHelper.GetFormatType - Begin. FileFormatType:{0}", formatType));
            return formatType;
        }

        /// <summary>
        /// to get mime type
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>returns mime type</returns>
        public static string GetMimeType(string fileName)
        {
            LogHelper.Info(string.Format("CommonHelper.GetMimeType - Begin. FileName:{0}", fileName));
            var extension = Path.GetExtension(fileName);
            LogHelper.Info(string.Format("Extension:{0}", extension));
            string mimeType = "application/unknown";
            if (!string.IsNullOrWhiteSpace(extension))
            {
                switch (extension.ToLowerInvariant())
                {
                    case ".jpg":
                    case ".jpeg":
                        mimeType = "image/jpeg";
                        break;
                    case ".png":
                        mimeType = "image/png";
                        break;

                    case ".ppt":
                        mimeType = "application/vnd.ms-powerpoint";
                        break;
                    case ".pptx":
                        //mimeType = "application/mspowerpoint";
                        mimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                        break;

                    case ".doc":
                        mimeType = "application/msword";
                        break;
                    case ".docx":
                        //mimeType = "application/msword";
                        mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        break;

                    case ".xls":
                        mimeType = "application/vnd.ms-excel";
                        break;
                    case ".xlsx":
                        //mimeType = "application/excel";
                        mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;

                    case ".pdf":
                        mimeType = "application/pdf";
                        break;

                    case ".txt":
                        mimeType = "text/plain";
                        break;

                    default:
                        mimeType = "application/unknown";
                        break;
                }
            }
            LogHelper.Info(string.Format("CommonHelper.GetMimeType - End. FileName:{0} and MimeType:{1}", fileName, mimeType));
            return mimeType;
        }

        /// <summary>
        /// to get content string
        /// </summary>
        /// <param name="contentString">content string</param>
        /// <param name="remedyContent">content</param>
        /// <param name="fileName">filename</param>
        /// <returns></returns>
        public static string GetContentString(string contentString, string fileName, byte[] remedyContent)
        {
            LogHelper.Info(String.Format("CommonHelper.GetContentString - Begin. fileName:{0}", fileName));
            var content = contentString = remedyContent != null && remedyContent.Length > 0 ? Convert.ToBase64String(remedyContent) : contentString;
            if (!String.IsNullOrEmpty(content))
            {
                if (!contentString.StartsWith(ApiConstants.TextDataColon))
                {
                    //data:image/jpeg;base,
                    content = string.Format("data:{0};base64,{1}", GetMimeType(fileName), contentString);
                }
            }
            LogHelper.Info(String.Format("CommonHelper.GetContentString - End. fileName:{0}", fileName));
            return content;
        }

        /// <summary>
        /// to get content from content string
        /// </summary>
        /// <param name="contentString">content string</param>
        /// <returns></returns>
        public static byte[] GetContentFromContentString(string contentString)
        {
            LogHelper.Info(String.Format("CommonHelper.GetContentFromContentString - Begin."));
            var tempContent = new byte[] { };
            if (!string.IsNullOrWhiteSpace(contentString))
            {
                tempContent =
                    Convert.FromBase64String(contentString.StartsWith(ApiConstants.TextDataColon)
                                                 ? contentString.Substring(
                                                     contentString.IndexOf(
                                                         ApiConstants.TextSemiColonBase34Comma,
                                                         StringComparison.Ordinal) + 8)
                                                 : contentString);

            }
            LogHelper.Debug(string.Format("To get content end"));
            LogHelper.Info(String.Format("CommonHelper.GetContentFromContentString - Begin.Content Length:{0}", tempContent.Length));
            return tempContent;
        }

        /// <summary>
        /// Create randam string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="passPhrase"></param>
        /// <param name="initVector"></param>
        /// <returns></returns>
        public static string EncryptString(string plainText, string passPhrase, string initVector)
        {
            try
            {
                int sizeOf = CommonHelper.GetWebConfigValue<int>(WebConstants.SizeOf);
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(sizeOf / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        byte[] cipherTextBytes = memoryStream.ToArray();
                        memoryStream.Close();
                        cryptoStream.Close();
                        return Convert.ToBase64String(cipherTextBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("CommonHelper.EncryptString - Exception:{0}", ex.Message));
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="passPhrase"></param>
        /// <param name="initVector"></param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, string passPhrase, string initVector)
        {
            int sizeOf = CommonHelper.GetWebConfigValue<int>(WebConstants.AppSecurityKey);
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(sizeOf / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
