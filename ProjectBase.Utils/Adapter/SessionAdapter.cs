using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectBase.Utils.Commons;

namespace ProjectBase.Utils.Adapter
{
    public static class SessionAdapter
    {
        public static IUserAccount User
        {
            get
            {
                if (null == CurrentPage)
                {
                    throw new Exception("Page cannot be null.");
                }

                return CurrentPage.Session[SESSION_NAME] as IUserAccount;
            }

            set { CurrentPage.Session[SESSION_NAME] = value; }
        }

        private static System.Web.UI.Page CurrentPage
        {
            get { return HttpContext.Current.Handler as System.Web.UI.Page; }
        }

        private static readonly string SESSION_NAME = "User";
    }
}