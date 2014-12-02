using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Commons
{
    public interface IMultiLanguageEntity
    {
        #region IMultiLanguageEntity Members
        string ThaiName { get; set; }
        string EnglishName { get; set; }
        #endregion
    }
}
