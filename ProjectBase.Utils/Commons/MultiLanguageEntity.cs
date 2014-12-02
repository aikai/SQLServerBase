using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;

namespace ProjectBase.Utils.Commons
{
    [Serializable]
    public class MultiLanguageEntity : IMultiLanguageEntity
    {
        #region IMultiLanguageEntity Members
        public virtual string ThaiName { get; set; }
        public virtual string EnglishName { get; set; }
        public virtual string ShortName { get; set; }
        #endregion
    }
}
