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
    public class HrDepartDao : NHibernateDao<IHrDepart>, IHrDepartDao
    {
        protected override IQueryOver<IHrDepart, IHrDepart> BuildId(IQueryOver<IHrDepart, IHrDepart> query, object id)
        {
            var _id = Convert.ToInt64(id);

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IHrDepart, IHrDepart> BuildInIds(IQueryOver<IHrDepart, IHrDepart> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IHrDepart, IHrDepart> BuildSort(IQueryOver<IHrDepart, IHrDepart> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IHrDepart entity)
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

        public override void Delete(IHrDepart entity)
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