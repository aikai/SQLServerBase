using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public abstract class ValueValidation : IValueValidation
    {
        protected abstract string ValidationExpressions { get; }
        protected abstract string ExceptionMessage { get; }

        #region IValue Members
        public virtual object Value { get; set; }
        #endregion

        #region IValidable Members
        public virtual bool HasValue
        {
            get
            {
                try
                {
                    return !object.ReferenceEquals(Value, null);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual bool IsValid
        {
            get
            {
                var bValid = false;

                try
                {
                    if (HasValue && !string.IsNullOrEmpty(ValidationExpressions))
                    {
                        var regex = new Regex(ValidationExpressions);
                        bValid = regex.IsMatch(Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return bValid;
            }
        }

        public virtual void Validate()
        {
            try
            {
                if (!IsValid)
                {
                    throw new Exception(ExceptionMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public override string ToString()
        {
            try
            {
                return (HasValue) ? Value.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}