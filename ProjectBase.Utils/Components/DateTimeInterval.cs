using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class DateTimeInterval : IDateTimeInterval
    {
        #region IDateTimeInterval Members
        public virtual IValueValidation StartDateTime { get; set; }
        public virtual IValueValidation EndDateTime { get; set; }
        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            try
            {
                if (StartDateTime.HasValue)
                {
                    var start = (DateTime)StartDateTime.Value;
                    sb.Append(start.ToString(Format.Instance.DateTime));
                }

                if (EndDateTime.HasValue)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" - ");
                    }

                    var end = (DateTime)EndDateTime.Value;
                    sb.Append(end.ToString(Format.Instance.DateTime));
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
