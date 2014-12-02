using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class RedirectBuilder : JavaScriptBuilder
    {
        #region property
        public virtual string Url { protected get; set; }
        #endregion

        protected override string Build()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Url))
            {
                sb.AppendFormat("window.location.href = '{0}';", Url);
            }

            return sb.ToString();
        }
    }
}