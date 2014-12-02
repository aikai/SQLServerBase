using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public abstract class JavaScriptBuilder
    {
        #region Constant fields
        protected static readonly string START_TAG = "<script type='text/javascript'>";
        protected static readonly string END_TAG = "</script>";
        #endregion

        #region Property
        protected static Page CurrentPage
        {
            get { return HttpContext.Current.Handler as Page; }
        }
        #endregion

        #region Method
        public static void Build(params JavaScriptBuilder[] builders)
        {
            if (builders != null && builders.Length > 0)
            {
                var sb = new StringBuilder();

                sb.Append(START_TAG);

                foreach (var builder in builders)
                {
                    sb.Append(builder.Build());
                }

                sb.Append(END_TAG);

                ScriptManager.RegisterStartupScript(CurrentPage, CurrentPage.GetType(), "script1", sb.ToString(), false);
            }
        }

        protected abstract string Build();
        #endregion
    }
}