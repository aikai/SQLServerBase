using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Commons
{
    [Serializable]
    public class MasterEntity : EntityBase, IMasterEntity
    {
        #region IMasterEntity Members
        public virtual string Name { get; set; }
        public virtual string ShortName { get; set; }
        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
