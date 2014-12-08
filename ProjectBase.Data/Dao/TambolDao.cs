using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;

namespace ProjectBase.Data
{
    public class TambolDao : ProviderDao<ITambol>, ITambolDao
    {
        protected override ITambol GetEntity(System.Data.IDataReader dr)
        {
            return base.GetEntity(dr);
        }
    }
}
