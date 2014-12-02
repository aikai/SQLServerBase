using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    public interface IFormat
    {
        #region My properties
        string Date { get; set; }
        string DateTime { get; set; }
        string Time { get; set; }
        string ThaiDate { get; set; }
        string ThaiDateShort { get; set; }
        string ThaiDateTime { get; set; }
        string ThaiTime { get; set; }
        #endregion
    }
}
