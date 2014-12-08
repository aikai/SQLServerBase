using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;

namespace ProjectBase.Data
{
    public class HrPositionDao : ProviderDao<IHrPosition>, IHrPositionDao
    {
        protected override IHrPosition GetEntity(System.Data.IDataReader dr)
        {
            return base.GetEntity(dr);
        }
    }
}