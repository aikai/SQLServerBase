using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using ProjectBase.Data.Model;

namespace ProjectBase.Data
{
    /// <summary>
    /// Exposes access to entity classes.  Motivation for this entity
    /// </summary>
    [Serializable]
    public class EntityFactory : IEntityFactory
    {
        public EntityFactory() { }

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static EntityFactory Instance
        {
            get
            {
                try
                {
                    return Nested.EntityFactory;
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
            internal static readonly EntityFactory EntityFactory = new EntityFactory();
        }
        #endregion

        public IProvince CreateProvince()
        {
            return new Province();
        }

        public IAmphoe CreateAmphoe()
        {
            return new Amphoe();
        }

        public ITambol CreateTambol()
        {
            return new Tambol();
        }

        public IAddress CreateAddress()
        {
            return new Address();
        }

        public IHrPosition CreateHrPosition()
        {
            return new HrPosition();
        }

        #region Inline Entity implementations
        /// <summary>
        /// Concrete entity for accessing instances of <see cref="Customs" /> from DB.
        /// This should be extracted into its own class-file if it needs to extend the
        /// inherited Entity functionality.
        /// </summary>
        
        #endregion
    }
}