using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using ProjectBase.Core;

namespace ProjectBase.Data
{
    public delegate void OnUpdate(DbCommand cmd);

    public abstract class ProviderDao<T> : Config, IDao<T> where T : class
    {
        public ProviderDao()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected StringBuilder sb = new StringBuilder();

        protected object SetDbNullToNull(object value)
        {
            try
            {
                return value is DBNull ? null : value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            try
            {
                return ExecuteReader(cmd, CommandBehavior.Default);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            try
            {
                sb.Remove(0, sb.Length);

                return cmd.ExecuteReader(behavior);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            try
            {
                sb.Remove(0, sb.Length);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            try
            {
                sb.Remove(0, sb.Length);

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Helper
        protected virtual void Update(OnUpdate onUpdate)
        {
            using (DbConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                // Start a local transaction.
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    // Must assign both transaction object and connection 
                    // to Command object for a pending local transaction
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    try
                    {
                        onUpdate(cmd);

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
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

                T entity = null;

                using (DbConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();

                    var cmd = conn.CreateCommand();

                    BuildQueryId(id, cmd);

                    // Must assign connection 
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    var dr = ExecuteReader(cmd);

                    entity = GetEntity(dr);
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Loads an instance of type TypeOfListItem from the DB based on its any ID.
        /// </summary>
        public virtual IList<T> GetInIds(object[] ids)
        {
            try
            {
                if (VerifyAvailableIsNull(ids)) return default(IList<T>);

                IList<T> entities = null;

                using (DbConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();

                    BuildQueryIds(ids);

                    var cmd = conn.CreateCommand();

                    // Must assign connection 
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    var dr = ExecuteReader(cmd);

                    entities = GetEntities(dr);
                }

                return entities;
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
                IList<T> entities = null;

                using (DbConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();

                    BuildQueryAll();

                    var cmd = conn.CreateCommand();

                    // Must assign connection 
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    var dr = ExecuteReader(cmd);

                    entities = GetEntities(dr);
                }

                return entities;
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

                IList<T> entities = null;

                using (DbConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();

                    BuildQueryParent(parentId);

                    var cmd = conn.CreateCommand();

                    // Must assign connection 
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    var dr = ExecuteReader(cmd);

                    entities = GetEntities(dr);
                }

                return entities;
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
        public virtual void Save(T entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(DbCommand cmd)
                {
                    BuildQuerySave(entity, cmd);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    ExecuteNonQuery(cmd);
                });
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

                Update(delegate(DbCommand cmd)
                {
                    BuildQueryUpdate(entity, cmd);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    ExecuteNonQuery(cmd);
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

                Update(delegate(DbCommand cmd)
                {
                    BuildQueryDelete(entity, cmd);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    ExecuteNonQuery(cmd);
                });
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

                Update(delegate(DbCommand cmd)
                {
                    BuildQueryDelete(entities, cmd);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    ExecuteNonQuery(cmd);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region IDao<T,I> Methods
        protected virtual void BuildQuerySave(T entity, DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected virtual void BuildQueryUpdate(T entity, DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected virtual void BuildQueryDelete(T entity, DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected virtual void BuildQueryDelete(T[] entities, DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected virtual T CreateEntity(IDataReader dr)
        {
            throw new NotImplementedException();
        }

        protected virtual T GetEntity(IDataReader dr)
        {
            if (VerifyAvailableIsNull(dr)) return default(T);

            T entity = null;

            while (dr.Read())
            {
                entity = CreateEntity(dr);
            }

            return entity;
        }

        protected virtual IList<T> GetEntities(IDataReader dr)
        {
            if (VerifyAvailableIsNull(dr)) return default(IList<T>);

            var entities = new List<T>();

            while (dr.Read())
            {
                entities.Add(CreateEntity(dr));
            }

            return entities;
        }

        protected virtual void BuildQueryId(object id, DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected virtual void BuildQueryIds(object[] ids)
        {
            throw new NotImplementedException();
        }

        protected virtual void BuildQueryParent(object parentId)
        {
            throw new NotImplementedException();
        }

        protected virtual void BuildQueryAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}