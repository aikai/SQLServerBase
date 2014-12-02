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
    public class UaeProjectManageDao : NHibernateDao<IUaeProjectManage>, IUaeProjectManageDao
    {
        protected override IQueryOver<IUaeProjectManage, IUaeProjectManage> BuildId(IQueryOver<IUaeProjectManage, IUaeProjectManage> query, object id)
        {
            var _id = Convert.ToString(id);

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IUaeProjectManage, IUaeProjectManage> BuildInIds(IQueryOver<IUaeProjectManage, IUaeProjectManage> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IUaeProjectManage, IUaeProjectManage> BuildSort(IQueryOver<IUaeProjectManage, IUaeProjectManage> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IUaeProjectManage, IUaeProjectManage> BuildExistence(IQueryOver<IUaeProjectManage, IUaeProjectManage> query, IUaeProjectManage entity)
        {
            return base.BuildExistence(query, entity).WhereRestrictionOn(x => x.Id).IsLike(entity.Id, MatchMode.Exact);
        }

        //protected int GetMaxInctNum(int year)
        //{
        //    var max = 0;

        //    try
        //    {
        //        if (1 > year)
        //        {
        //            throw new Exception("Year is less than zero.");
        //        }

        //        var s = Session;

        //        if (!VerifyAvailableIsNull(s))
        //        {
        //            IUaeProjectManage e = null;

        //            var query = s.QueryOver(() => e)
        //                         .Where(() => e.ProjYear == year)
        //                         .Select(Projections.ProjectionList()
        //                            .Add(Projections.Max(() => e.InctNum)))
        //                         .List<int?>().First();

        //            if (!VerifyAvailableIsNull(query))
        //            {
        //                max = query.Value;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return max;
        //}

        //public override object Save(IUaeProjectManage entity)
        //{
        //    try
        //    {
        //        if (VerifyAvailableIsNull(entity)) return null;

        //        object id = null;
        //        Update(delegate(ISession s)
        //        {
        //            var sb = new StringBuilder();
        //            var toDay = DateTime.Now;
        //            var max = this.GetMaxInctNum(toDay.Year);// Maximum value: 999.

        //            entity.ProjYear = toDay.Year;

        //            do
        //            {
        //                sb.Remove(0, sb.Length);
        //                max++;// Increment maximum value.
        //                sb.AppendFormat("{0}-51200", entity.ProjYear);
        //                sb.AppendFormat("-{0:000}", max);

        //                entity.InctNum = max;
        //                entity.ProjCode = string.Format("51200-{0:000}", max);
        //                entity.Id = sb.ToString();

        //            } while (max <= 999 && this.IsExist(entity));

        //            if (max <= 999)
        //            {
        //                s.Clear();
        //                id = s.Save(entity);
        //            }
        //        });
        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public override void Update(IUaeProjectManage entity)
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

        public override void Delete(IUaeProjectManage entity)
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

        //public IList<IUaeProjectManage> Search(string projId, string projTname)
        //{
        //    try
        //    {
        //        var s = Session;
        //        if (null == s) return null;

        //        var query = s.QueryOver<IUaeProjectManage>();

        //        if (!string.IsNullOrEmpty(projId))
        //        {
        //            query.WhereRestrictionOn(x => x.Id)
        //                 .IsInsensitiveLike(projId, MatchMode.Anywhere);
        //        }

        //        if (!string.IsNullOrEmpty(projTname))
        //        {
        //            query.WhereRestrictionOn(x => x.ProjTname)
        //                 .IsInsensitiveLike(projTname, MatchMode.Anywhere);
        //        }

        //        return query.OrderBy(x => x.Id).Asc
        //                    .ThenBy(x => x.ProjTname).Asc
        //                    .List();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public IList<IUaeProjectManage> Search(DateTime? startDate, DateTime? endDate, string dept, 
        //        string projCode, string projTname, string projEname)
        //{
        //    try
        //    {
        //        var s = Session;
        //        if (VerifyAvailableIsNull(s)) return default(IList<IUaeProjectManage>);

        //        IUaeProjectManage e = null;

        //        var query = s.QueryOver(() => e);

        //        if (startDate != null && startDate.HasValue)
        //        {
        //            var date = startDate.Value.AddDays(-1);
        //            query.Where(() => e.ProjDatestart > date);
        //        }

        //        if (endDate != null && endDate.HasValue)
        //        {
        //            var date = endDate.Value.AddDays(1);
        //            query.Where(() => e.ProjDateend < date);
        //        }

        //        if (!string.IsNullOrEmpty(dept))
        //        {
        //            query.WhereRestrictionOn(() => e.ProjDepartment).IsLike(dept, MatchMode.Exact);
        //        }

        //        if (!string.IsNullOrEmpty(projCode))
        //        {
        //            query.WhereRestrictionOn(() => e.ProjCode).IsLike(projCode, MatchMode.Anywhere);
        //        }

        //        if (!string.IsNullOrEmpty(projTname))
        //        {
        //            query.WhereRestrictionOn(() => e.ProjTname).IsLike(projTname, MatchMode.Anywhere);
        //        }

        //        if (!string.IsNullOrEmpty(projEname))
        //        {
        //            query.WhereRestrictionOn(() => e.ProjEname).IsLike(projEname, MatchMode.Anywhere);
        //        }

        //        return query.List();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
