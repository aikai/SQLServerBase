using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class AlertBuilder : JavaScriptBuilder
    {
        #region Constructors
        public AlertBuilder()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public AlertBuilder(string message)
        {
            //
            // TODO: Add constructor logic here
            //

            Message = message;
        }
        #endregion

        #region Property
        public virtual string Message { get; set; }
        #endregion

        protected override string Build()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Message))
            {
                sb.AppendLine(string.Format("alert(\"{0}\");",
                    Message.Replace("'", "\'").Replace("\"", "\'").Replace("\r\n", "\" + \"\\n\" + \"")));
            }

            return sb.ToString();
        }
    }
}