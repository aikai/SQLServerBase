using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class CloseWindowBuilder : JavaScriptBuilder
    {
        #region property
        public virtual string PreScript { protected get; set; }
        public virtual string NavigateUrl { protected get; set; }
        #endregion

        protected override string Build()
        {
            var script = string.Format("{0}{1}", PreScript, "window.close();");

            if (!string.IsNullOrEmpty(NavigateUrl))
            {
                script = string.Format("{0}{1}", script,
                    string.Format("window.location.href = '{0}';", NavigateUrl));
            }

            return script;
        }
    }
}
