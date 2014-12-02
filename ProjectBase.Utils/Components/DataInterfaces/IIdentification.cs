using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    public interface IIdentification
    {
        #region IIdentification Members
        Guid Id { get; set; }
        #endregion
    }
}
