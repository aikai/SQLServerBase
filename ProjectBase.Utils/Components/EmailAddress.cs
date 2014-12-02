using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class EmailAddress : ValueValidation
    {
        protected override string ValidationExpressions
        {
            get
            {
                try
                {
                    return ValidationExpression.Instance.EmailAddress;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override string ExceptionMessage
        {
            get { return "Invalid email address."; }
        }
    }
}
