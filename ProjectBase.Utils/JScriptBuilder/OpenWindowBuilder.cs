using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class OpenWindowBuilder : JavaScriptBuilder
    {
        #region property
        public virtual string Url { get; set; }
        #endregion

        protected override string Build()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Url))
            {
                sb.AppendFormat(@"window.open('{0}');", Url);
            }

            return sb.ToString();
        }
    }
}