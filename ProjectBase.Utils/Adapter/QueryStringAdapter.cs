using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectBase.Utils.Commons;

namespace ProjectBase.Utils.Adapter
{
    public static class QueryStringAdapter
    {
        public struct Name
        {
            public const string Mode = "mode";
            public const string EditId = "edit_id";
            public const string PrintId = "print_id";
        }

        private static string Get(string name)
        {
            return HttpContext.Current.Handler == null ? null : 
                ((System.Web.UI.Page)HttpContext.Current.Handler).Request.QueryString[name];
        }

        public static string Mode
        {
            get { return Get(Name.Mode); }
        }

        public static string EditId
        {
            get { return Get(Name.EditId); }
        }

        public static string PrintId
        {
            get { return Get(Name.PrintId); }
        }
    }
}