using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class FunctionBuilder : JavaScriptBuilder
    {
        #region Constant fields
        protected static readonly string SCRIPT_FUNCTION = "function";
        protected static readonly string DEFAULT_NAME = "JScript";
        protected static readonly string PARENTHESES_START = "(";
        protected static readonly string PARENTHESES_END = ")";
        protected static readonly string CURLY_BRACES_START = "{";
        protected static readonly string CURLY_BRACES_END = "}";
        #endregion

        #region Constructors
        public FunctionBuilder()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public FunctionBuilder(string script_block)
        {
            //
            // TODO: Add constructor logic here
            //

            Script_Block = script_block;
        }

        public FunctionBuilder(string name, string script_block)
        {
            //
            // TODO: Add constructor logic here
            //

            Name = name;
            Script_Block = script_block;
        }

        public FunctionBuilder(string name, string parameter, string script_block)
        {
            //
            // TODO: Add constructor logic here
            //

            Name = name;
            Parameter = parameter;
            Script_Block = script_block;
        }
        #endregion

        #region Property
        public virtual string Name { get; set; }
        public virtual string Parameter { get; set; }
        public virtual string Script_Block { get; set; }
        #endregion

        protected override string Build()
        {
            var sb = new StringBuilder();

            sb.Append(SCRIPT_FUNCTION);

            if (string.IsNullOrEmpty(Name))
            {
                sb.AppendFormat(" {0}", DEFAULT_NAME);
            }
            else
            {
                sb.AppendFormat(" {0}", Name);
            }

            sb.Append(PARENTHESES_START);

            if (!string.IsNullOrEmpty(Parameter))
            {
                sb.Append(Parameter);
            }

            sb.Append(PARENTHESES_END);
            sb.Append(CURLY_BRACES_START);

            if (!string.IsNullOrEmpty(Script_Block))
            {
                sb.Append(Script_Block);
            }

            sb.Append(CURLY_BRACES_END);

            return sb.ToString();
        }
    }
}