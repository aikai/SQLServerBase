using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate;
using ProjectBase.Data;
using ProjectBase.Core;

namespace ProjectBase.Data
{
    public delegate void OnUpdate(ISession session);

    public abstract class NHibernateDao<T> : IDao<T> where T : class
    {
        #region Properties
        /// <summary>
        /// Exposes the ISession used within the DAO.
        /// </summary>
        protected virtual ISession Session
        {
            get { return SessionManager.OpenSession(); }
        }

        private System.Type persitentType = typeof(T);
        #endregion

        #region Helper
        protected virtual void Update(OnUpdate onUpdate)
        {
            var s = Session;
            if (VerifyAvailableIsNull(s)) return;

            try
            {
                s.BeginTransaction();
                onUpdate(s);
                s.Transaction.Commit();
            }
            catch (Exception ex)
            {
                s.Transaction.Rollback();
                throw ex;
            }
        }

        protected virtual bool VerifyAvailableIsNull(object obj)
        {
            return object.ReferenceEquals(obj, null);
        }

        protected virtual bool VerifyAvailableEquals(object objA, object objB)
        {
            return object.ReferenceEquals(objA, objB);
        }

        protected virtual void VerifyAvailableQuery(IQueryOver<T, T> query)
        {
            if (null == query)
            {
                throw new Exception("Query cannot be null.");
            }
        }

        protected virtual void VerifyAvailableEntity(T entity)
        {
            if (null == entity)
            {
                throw new Exception("Entity cannot be null.");
            }
        }
        #endregion

        #region IDao<T,I> Members
        /// <summary>
        /// Loads an instance of type TypeOfListItem from the DB based on its ID.
        /// </summary>
        public virtual T GetById(object id)
        {
            try
            {
                if (VerifyAvailableIsNull(id)) return default(T);

                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(T);

                T entity = null;
                var query = s.QueryOver<T>();

                query = BuildId(query, id);
                entity = query.SingleOrDefault();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Loads an instance of type TypeOfListItem from the DB based on its ID.
        /// </summary>
        public T GetById(object id, bool shouldLock)
        {
            try
            {
                if (VerifyAvailableIsNull(id)) return default(T);

                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(T);

                T entity = null;

                if (shouldLock)
                {
                    entity = (T)s.Load(persitentType, id, LockMode.Upgrade);
                }
                else
                {
                    entity = (T)s.Load(persitentType, id);
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> GetInIds(object[] ids)
        {
            try
            {
                if (VerifyAvailableIsNull(ids)) return default(IList<T>);

                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<T>);

                var query = s.QueryOver<T>();

                query = BuildInIds(query, ids);
                query = BuildSort(query);

                return query.List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Loads every instance of the requested type with no filtering.
        /// </summary>
        public virtual IList<T> GetAll()
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<T>);

                var query = s.QueryOver<T>();

                query = BuildSort(query);

                return query.List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Loads every instance of the requested type using the supplied <see cref="ICriterion" />.
        /// If no <see cref="ICriterion" /> is supplied, this behaves like <see cref="GetAll" />.
        /// </summary>
        public virtual IList<T> GetByCriteria(T criteria)
        {
            try
            {
                if (VerifyAvailableIsNull(criteria)) return default(IList<T>);

                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<T>);

                var query = s.QueryOver<T>();

                query = BuildJoin(query);
                query = BuildSearch(query, criteria);
                query = BuildSort(query);

                return query.List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> GetByCriteria(params ICriterion[] criterion)
        {
            try
            {
                if (VerifyAvailableIsNull(criterion)) return default(IList<T>);

                ICriteria criteria = Session.CreateCriteria(persitentType);

                foreach (ICriterion criterium in criterion)
                {
                    criteria.Add(criterium);
                }

                return criteria.List<T>() as List<T>;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> GetByParent(object parentId)
        {
            try
            {
                if (VerifyAvailableIsNull(parentId)) return default(IList<T>);

                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<T>);

                T e = null;

                var query = s.QueryOver(() => e);

                query = BuildParent(query, parentId);
                query = BuildSort(query);

                return query.List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int GetCount(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return 0;

                var s = Session;
                if (VerifyAvailableIsNull(s)) return 0;

                var query = s.QueryOver<T>();

                query = BuildJoin(query);
                query = BuildSearch(query, entity);

                return query.RowCount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool IsExist(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return false;

                var s = Session;
                if (VerifyAvailableIsNull(s)) return false;

                var query = s.QueryOver<T>();

                query = BuildExistence(query, entity);

                var o = query.List<T>();

                return o != null && o.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For entities that have assigned ID's, you must explicitly call Save to add a new one.
        /// See http://www.hibernate.org/hib_docs/reference/en/html/mapping.html#mapping-declaration-id-assigned.
        /// </summary>
        public virtual object Save(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;

                object id = null;
                Update(delegate(ISession s) { id = s.Save(entity); });
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s)
                {
                    s.Clear();
                    s.Update(entity);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s) { s.Delete(entity); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T[] entities)
        {
            try
            {
                if (VerifyAvailableIsNull(entities)) return;

                Update(delegate(ISession s)
                {
                    s.Clear();

                    foreach (var entity in entities)
                    {
                        s.Delete(entity);
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For entities with automatatically generated IDs, such as identity, SaveOrUpdate may 
        /// be called when saving a new entity.  SaveOrUpdate can also be called to update any 
        /// entity, even if its ID is assigned.
        /// </summary>
        public virtual void SaveOrUpdate(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s) { s.SaveOrUpdate(entity); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void DeleteAndSave(T entity)
        {
            if (VerifyAvailableIsNull(entity)) return;

            var s = Session;
            if (VerifyAvailableIsNull(s)) return;

            try
            {
                s.BeginTransaction();

                s.Delete(entity);
                s.Flush();
                s.Save(entity);

                s.Transaction.Commit();
            }
            catch (Exception ex)
            {
                s.Transaction.Rollback();
                throw ex;
            }
        }
        #endregion

        #region IDao<T,I> Methods
        protected virtual IQueryOver<T, T> BuildId(IQueryOver<T, T> query, object id)
        {
            VerifyAvailableQuery(query);
            return query;
        }

        protected virtual IQueryOver<T, T> BuildInIds(IQueryOver<T, T> query, object[] ids)
        {
            VerifyAvailableQuery(query);
            return query;
        }

        protected virtual IQueryOver<T, T> BuildParent(IQueryOver<T, T> query, object parentId)
        {
            VerifyAvailableQuery(query);
            return query;
        }

        protected virtual IQueryOver<T, T> BuildSort(IQueryOver<T, T> query)
        {
            VerifyAvailableQuery(query);
            return query;
        }

        protected virtual IQueryOver<T, T> BuildJoin(IQueryOver<T, T> query)
        {
            VerifyAvailableQuery(query);
            return query;
        }

        protected virtual IQueryOver<T, T> BuildSearch(IQueryOver<T, T> query, T entity)
        {
            VerifyAvailableQuery(query);
            return query;
        }

        protected virtual IQueryOver<T, T> BuildExistence(IQueryOver<T, T> query, T entity)
        {
            VerifyAvailableQuery(query);
            return query;
        }
        #endregion
    }
}
