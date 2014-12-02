using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class ScriptBlockBuilder : JavaScriptBuilder
    {
        #region Constructors
        public ScriptBlockBuilder()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ScriptBlockBuilder(string script)
        {
            //
            // TODO: Add constructor logic here
            //

            ScriptBlock = script;
        }
        #endregion

        #region Property
        public virtual string ScriptBlock { get; set; }
        #endregion

        protected override string Build()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(ScriptBlock))
            {
                sb.AppendLine(ScriptBlock.Replace("'", "\'").Replace("\"", "\'").Replace("\r\n", "\" + \"\\n\" + \""));
            }

            return sb.ToString();
        }
    }
}