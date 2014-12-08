using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Core
{
    public interface IDao<T> where T : class
    {
        T GetById(object id);
        
        IList<T> GetAll();
        IList<T> GetInIds(object[] ids);
        IList<T> GetByParent(object parentId);

        object Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(T[] entities);
    }
}
