using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Commons
{
    public interface IUserAccount
    {
        #region IUserAccount Members
        string UserId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        #endregion
    }
}
