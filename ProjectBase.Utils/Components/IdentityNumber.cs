using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class IdentityNumber : ValueValidation
    {
        protected override string ValidationExpressions
        {
            get
            {
                try
                {
                    return ValidationExpression.Instance.CitizenNumber;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override string ExceptionMessage
        {
            get { return "Invalid identity number."; }
        }
    }
}
