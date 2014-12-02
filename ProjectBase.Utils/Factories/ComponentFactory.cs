using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils
{
    [Serializable]
    public class ComponentFactory : IComponentFactory
    {
        public ComponentFactory() { }

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static ComponentFactory Instance
        {
            get
            {
                try
                {
                    return Nested.ComponentFactory;
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
            internal static readonly ComponentFactory ComponentFactory = new ComponentFactory();
        }
        #endregion

        #region IComponentFactory Members
        public IDateTimeInterval CreateDateTimeInterval()
        {
            return new DateTimeInterval();
        }

        public IValueValidation CreateDateTime()
        {
            return new DateTimes();
        }

        public IValueValidation CreateEmailAddress()
        {
            return new EmailAddress();
        }

        public IValueValidation CreateIdentityNumber()
        {
            return new IdentityNumber();
        }

        public IValueValidation CreateTelephoneNumber()
        {
            return new TelephoneNumber();
        }

        public IValueValidation CreateMobilephoneNumber()
        {
            return new MobilephoneNumber();
        }

        public IValueValidation CreatePostCode()
        {
            return new PostCode();
        }

        public IValidationExpression CreateValidationExpression()
        {
            return ValidationExpression.Instance;
        }

        public IFormat CreateFormat()
        {
            return Format.Instance;
        }

        // Commons Entity
        public IEntityBase CreateEntityBase()
        {
            return new EntityBase();
        }
        public IMasterEntity CreateMasterEntity()
        {
            return new MasterEntity();
        }
        public IMultiLanguageEntity CreateMultiLanguageEntity()
        {
            return new MultiLanguageEntity();
        }

        public IUserAccount CreateUserAccount()
        {
            return new UserAccount();
        }

        public IUtility CreateUtility()
        {
            return new Utility();
        }

        public ISendEmail CreateSendEmail()
        {
            return new SendEmail();
        }
        #endregion
    }
}
