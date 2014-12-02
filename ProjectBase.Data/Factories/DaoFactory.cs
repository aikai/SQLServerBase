using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Data;
using ProjectBase.Core;

namespace ProjectBase.Data
{
    /// <summary>
    /// Exposes access to NHibernate DAO classes.  Motivation for this DAO
    /// framework can be found at http://www.hibernate.org/328.html.
    /// </summary>
    [Serializable]
    public class DaoFactory : IDaoFactory
    {
        public DaoFactory() { }

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static DaoFactory Instance
        {
            get
            {
                try
                {
                    return Nested.DaoFactory;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        protected class Nested
        {
            static Nested() { }
            internal static readonly DaoFactory DaoFactory = new DaoFactory();
        }
        #endregion

        public IProvinceDao GetProvinceDao()
        {
            return new ProvinceDao();
        }

        public IAmphoeDao GetAmphoeDao()
        {
            return new AmphoeDao();
        }

        public ITambolDao GetTambolDao()
        {
            return new TambolDao();
        }

        public IHrPositionDao GetHrPositionDao()
        {
            return new HrPositionDao();
        }

        public IHrDepartDao GetHrDepartDao()
        {
            return new HrDepartDao();
        }

        public IUaeProjectManageDao GetUaeProjectManageDao()
        {
            return new UaeProjectManageDao();
        }

        #region Inline DAO implementations
        /// <summary>
        /// Concrete DAO for accessing instances of <see cref="Customer" /> from DB.
        /// This should be extracted into its own class-file if it needs to extend the
        /// inherited DAO functionality.
        /// </summary>
        
        #endregion
    }
}
