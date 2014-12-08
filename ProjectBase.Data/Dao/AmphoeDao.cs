using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;

namespace ProjectBase.Data
{
    public class AmphoeDao : ProviderDao<IAmphoe>, IAmphoeDao
    {
        protected override IAmphoe GetEntity(System.Data.IDataReader dr)
        {
            return base.GetEntity(dr);
        }
    }
}
