using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;

namespace ProjectBase.Utils.Commons
{
    [Serializable]
    public class UserAccount : IUserAccount
    {
        #region IUserAccount Members
        public virtual string UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        #endregion
    }
}