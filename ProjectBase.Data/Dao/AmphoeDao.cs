using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;
using NHibernate.Criterion;

namespace ProjectBase.Data
{
    public class AmphoeDao : NHibernateDao<IAmphoe>, IAmphoeDao
    {
        protected override IQueryOver<IAmphoe, IAmphoe> BuildId(IQueryOver<IAmphoe, IAmphoe> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAmphoe, IAmphoe> BuildInIds(IQueryOver<IAmphoe, IAmphoe> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAmphoe, IAmphoe> BuildSort(IQueryOver<IAmphoe, IAmphoe> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IAmphoe, IAmphoe> BuildParent(IQueryOver<IAmphoe, IAmphoe> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IAmphoe e = null;

            return base.BuildParent(query, parentId).Where(() => e.Province.Id == _id);
        }

        public override void Update(IAmphoe entity)
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

        public override void Delete(IAmphoe entity)
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
