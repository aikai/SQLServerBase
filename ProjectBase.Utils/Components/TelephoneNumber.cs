using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class TelephoneNumber : ValueValidation
    {
        protected override string ValidationExpressions
        {
            get
            {
                try
                {
                    return ValidationExpression.Instance.TelephoneNumber;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override string ExceptionMessage
        {
            get { return "Invalid telephone number."; }
        }
    }
}
