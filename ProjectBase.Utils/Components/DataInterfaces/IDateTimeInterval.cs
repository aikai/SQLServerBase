using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    public interface IDateTimeInterval
    {
        IValueValidation StartDateTime { get; set; }
        IValueValidation EndDateTime { get; set; }
    }
}
