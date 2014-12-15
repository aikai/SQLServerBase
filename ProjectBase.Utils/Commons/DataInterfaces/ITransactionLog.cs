using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Commons
{
    public interface ITransactionLog
    {
        #region ITransactionLog Members
        string CreateBy { get; set; }
        DateTime CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime UpdateDate { get; set; }
        #endregion
    }
}
