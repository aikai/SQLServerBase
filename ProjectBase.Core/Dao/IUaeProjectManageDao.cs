using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IUaeProjectManageDao : IDao<IUaeProjectManage>
    {
        //IList<IUaeProjectManage> Search(string projId, string projTname);
        //IList<IUaeProjectManage> Search(DateTime? startDate, DateTime? endDate, string dept, string projCode, string projTname, string projEname);
    }
}
