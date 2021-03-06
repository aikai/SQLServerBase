﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Commons
{
    [Serializable]
    public class EntityBase : IEntityBase
    {
        #region IIdentification Members
        public virtual Guid Id { get; set; }
        #endregion

        #region IMultiLanguageEntity Members
        public virtual string ThaiName { get; set; }
        public virtual string EnglishName { get; set; }
        #endregion

        #region ITransactionLog Members
        public virtual string CreateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        #endregion

        public override string ToString()
        {
            return ThaiName;
        }
    }
}
