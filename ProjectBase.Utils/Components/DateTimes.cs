using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class DateTimes : ValueValidation
    {
        protected override string ValidationExpressions
        {
            get
            {
                try
                {
                    return ValidationExpression.Instance.DateTime;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override string ExceptionMessage
        {
            get { return "Invalid datetime."; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            try
            {
                if (this.HasValue)
                {
                    var datetime = (DateTime)this.Value;
                    sb.Append(datetime.ToString(Format.Instance.DateTime));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }
    }
}