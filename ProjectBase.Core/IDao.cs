using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Core
{
    public interface IDao<T> where T : class
    {
        T GetById(object id);
        T GetById(object id, bool shouldLock);
        
        IList<T> GetAll();
        IList<T> GetByCriteria(T criteria);
        IList<T> GetInIds(object[] ids);
        IList<T> GetByParent(object parentId);

        object Save(T entity);
        void SaveOrUpdate(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(T[] entities);
        void DeleteAndSave(T entity);

        int GetCount(T entity);
        bool IsExist(T entity);
    }
}
