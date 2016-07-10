using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Common
{
    public class ApiConstants
    {
        #region Consts
        public const string ExpiryMinutes = "AnWebExpiryMinutes";
        public const string AuthorizationToken = "AuthorizationToken";
        public const string StatusSuccess = "Success";
        public const string StatusFailure = "Failure";
        public const string WwwAuthenticate = "WWW-Authenticate";
        public const string BasicType = "Basic realm='api.local'";
        public const string SecurityKey = "SecurityKey";
        public const string StrCommaSeparator = ",";
        public const string Kb = "KB";
        public const string StrColonSpace = ": ";
        public const string Origin = "Origin";
        public const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        public const string ConstCodeType = "ConstCodeTypeToResolution";
        public const string ConstStatus = "ConstStatusToResolution";
        public const string ConstTicketType = "ConstTicketTypeToResolution";
        public const string ConstUserTypeSwitchTech = "ConstUserTypeSwitchTech";
        public const string ConstUserTypeDualUser = "ConstUserTypeDualUser";
        public const string ConstUserTypeCellTech = "ConstUserTypeCellTech";
        public const string ConstUserTypeOps = "ConstUserTypeOps";
        public const string ConstDurationMin = "ConstDurationMin";
        public const string ConstDurationMax = "ConstDurationMax";
        public const string ConstDualUser = "ConstDualUser";
        public const string AutoCompleteMinLength = "AutoCompleteMinLength";
        public const string LessThanStr = "&lt;";
        public const string GreaterThanStr = "&gt;";
        public const string LessThanSymbol1 = "&lt<";
        public const string GreaterThanSymbol1 = "&gt<";
        public const string LessThanReplace = "<";
        public const string GreaterThanReplace = ">";
        public const string ApostropheStr = "&apos;";
        public const string ApostropheSymbol = "'";
        public const string FormatBase64ImageMimeType = "data:image/{0};base64,";
        public const string FormatBase64ApplicationMimeType = "data:application/{0};base64,";
        public const string FormatBase64TxtMimeType = "data:text/{0};base64,";
        public const string TextUnknown = "unknown";
        public const string TextDataColon = "data:";
        public const string TextSemiColonBase34Comma = ";base64,";
        public const string ImageFileTypes = "jpg,jpeg,png";
        public const string ApplicationFileTypes = "docx,doc,ppt,pptx,xls,xlsx,pdf";
        public const string MegaByteLength = "MegaByteLength";
        public const string MaxFileAttachmentSize = "MaxFileAttachmentSize";
        public const string AttachmentFileTypes = "AttachmentFileTypes";
        public const string CommandConnectionTimeout = "CommandTimeout";
        public const string DateFormat = "";
        public const string TimeFormat = "";
        public const string ApiVersion = "1.0";
        public const string Username = "Username";
        public const string Password = "Password";
        #endregion

        #region Chars
        public const char CharCommaSeparator = ',';
        public const char CharHyphen = '-';
        public const char CharColon = ':';
        #endregion
    }

    public class WebConstants
    {
        public const string StatusSuccess = "Success";
        public const string StatusFailure = "Failure";

        public const string AppSecurityKey = "SecurityKeyApp";
        public const string SizeOf = "SizeofStudents";
    }
}
