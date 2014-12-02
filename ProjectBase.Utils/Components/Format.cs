using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class Format : ConfigurationSection, IFormat
    {
        public Format() { }

        #region My attributes, fields
        protected const string DATE = "DATE";
        protected const string DATE_TIME = "DATE_TIME";
        protected const string DATE_SHORT = "DATE_SHORT";
        protected const string TIME = "TIME";
        protected const string THDATE = "THDATE";
        protected const string THDATE_SHORT = "THDATE_SHORT";
        protected const string THDATE_TIME = "THDATE_TIME";
        protected const string THTIME = "THTIME";
        protected const string SECTION_NAME = "format-configuration";
        #endregion

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static Format Instance
        {
            get
            {
                try
                {
                    return Nested.Format;
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
            internal static readonly Format Format =
                ConfigurationManager.GetSection(SECTION_NAME) as Format;
        } 
        #endregion

        #region My properties
        [ConfigurationProperty(DATE)]
        public virtual string Date
        {
            get { return (string)this[DATE]; }
            set { this[DATE] = value; }
        }

        [ConfigurationProperty(DATE_TIME)]
        public virtual string DateTime
        {
            get { return (string)this[DATE_TIME]; }
            set { this[DATE_TIME] = value; }
        }

        [ConfigurationProperty(DATE_SHORT)]
        public virtual string DateShort
        {
            get { return (string)this[DATE_SHORT]; }
            set { this[DATE_SHORT] = value; }
        }

        [ConfigurationProperty(TIME)]
        public virtual string Time
        {
            get { return (string)this[TIME]; }
            set { this[TIME] = value; }
        }

        [ConfigurationProperty(THDATE)]
        public virtual string ThaiDate
        {
            get { return (string)this[THDATE]; }
            set { this[THDATE] = value; }
        }

        [ConfigurationProperty(THDATE_SHORT)]
        public virtual string ThaiDateShort
        {
            get { return (string)this[THDATE_SHORT]; }
            set { this[THDATE_SHORT] = value; }
        }

        [ConfigurationProperty(THDATE_TIME)]
        public virtual string ThaiDateTime
        {
            get { return (string)this[THDATE_TIME]; }
            set { this[THDATE_TIME] = value; }
        }

        [ConfigurationProperty(THTIME)]
        public virtual string ThaiTime
        {
            get { return (string)this[THTIME]; }
            set { this[THTIME] = value; }
        }
        #endregion
    }
}
