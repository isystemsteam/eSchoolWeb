using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSchool.Web
{
    public static class Extension
    {
        public static T GetFormValue<T>(this FormCollection collection, string keyName)
        {
            string value = string.Empty;
            if (collection[keyName] != null && !string.IsNullOrWhiteSpace(collection[keyName]))
            {
                if (typeof(T).GetType() == typeof(bool).GetType())
                {
                    value = string.Compare(collection[keyName], "on") == 0 ? "true" : "false";
                }
                else
                {
                    value = collection[keyName];
                }
            }

            return !string.IsNullOrWhiteSpace(value) ? (T)Convert.ChangeType(value, typeof(T)) : default(T);
        }
    }
}