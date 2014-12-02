using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    public interface IValueValidation
    {
        object Value { get; set; }
        bool HasValue { get; }
        bool IsValid { get; }
        void Validate();
    }
}
