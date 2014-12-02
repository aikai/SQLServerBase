using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class TambolDao : NHibernateDao<ITambol>, ITambolDao
    {
        protected override IQueryOver<ITambol, ITambol> BuildId(IQueryOver<ITambol, ITambol> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<ITambol, ITambol> BuildInIds(IQueryOver<ITambol, ITambol> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<ITambol, ITambol> BuildSort(IQueryOver<ITambol, ITambol> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<ITambol, ITambol> BuildParent(IQueryOver<ITambol, ITambol> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            ITambol e = null;

            return base.BuildParent(query, parentId).Where(() => e.Amphoe.Id == _id);
        }

        public override void Update(ITambol entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s)
                {
                    s.Clear();
                    s.Update(s.Merge(entity));
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(ITambol entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s) { s.Delete(s.Merge(entity)); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
