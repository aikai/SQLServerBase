using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class MobilephoneNumber : ValueValidation
    {
        protected override string ValidationExpressions
        {
            get
            {
                try
                {
                    return ValidationExpression.Instance.MobilephoneNumber;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override string ExceptionMessage
        {
            get { return "Invalid mobilephone number."; }
        }
    }
}