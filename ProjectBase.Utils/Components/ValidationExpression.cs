using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Components
{
    [Serializable]
    public class ValidationExpression : ConfigurationSection, IValidationExpression
    {
        public ValidationExpression() { }

        #region My attributes, fields
        //TIME="^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$"
        //DATE_TIME="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?"
        //EMAIL_ADDRESS="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        //MOBILEPHONE_NUMBER="\d{10}"
        //TELEPHONE_NUMBER="\d{9}"
        //MONEY="^\$?[0-9]+(,[0-9]{3})*(\.[0-9]{2}|.[0-9]{1})?$"
        //INTEGER_NUMBER="^\$?[0-9]+(,[0-9]{3})*?$"
        //DECIMAL_NUMBER="^[0-9]*[.]{0,1}[0-9]{0,8}$"
        //CITIZEN_NUMBER="\d{13}"
        //PASSPORT_NUMBER="\d{13}"
        //POSTCODE="\d{5}"
        //THAI_ALPHABET="^[ก-๙0-9]+$"
        //ENGLISH_ALPHABET="^[a-zA-Z0-9]+$"
        //PASSWORD="^[a-zA-Z0-9]{6,20}$"
        //PIN="\d{4}"
        //POSITIVE_INTEGER="^\d+$"
        //WEBSITE_URL="http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";

        protected const string TIME = "TIME";
        protected const string DATE_TIME = "DATE_TIME";
        protected const string EMAIL_ADDRESS = "EMAIL_ADDRESS";
        protected const string MOBILEPHONE_NUMBER = "MOBILEPHONE_NUMBER";
        protected const string TELEPHONE_NUMBER = "TELEPHONE_NUMBER";
        protected const string MONEY = "MONEY";
        protected const string INTEGER_NUMBER = "INTEGER_NUMBER";
        protected const string DECIMAL_NUMBER = "DECIMAL_NUMBER";
        protected const string CITIZEN_NUMBER = "CITIZEN_NUMBER";
        protected const string PASSPORT_NUMBER = "PASSPORT_NUMBER";
        protected const string POSTCODE = "POSTCODE";
        protected const string THAI_ALPHABET = "THAI_ALPHABET";
        protected const string ENGLISH_ALPHABET = "ENGLISH_ALPHABET";
        protected const string PASSWORD = "PASSWORD";
        protected const string PIN = "PIN";
        protected const string POSITIVE_INTEGER = "POSITIVE_INTEGER";
        protected const string WEBSITE_URL = "WEBSITE_URL";
        protected const string SECTION_NAME = "validation-expression-configuration";
        #endregion

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static ValidationExpression Instance
        {
            get
            {
                try
                {
                    return Nested.ValidationExpression;
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
            internal static readonly ValidationExpression ValidationExpression =
                ConfigurationManager.GetSection(SECTION_NAME) as ValidationExpression;
        } 
        #endregion

        #region My properties
        [ConfigurationProperty(TIME)]
        public virtual string Time
        {
            get { return (string)this[TIME]; }
            set { this[TIME] = value; }
        }

        [ConfigurationProperty(DATE_TIME)]
        public virtual string DateTime
        {
            get { return (string)this[DATE_TIME]; }
            set { this[DATE_TIME] = value; }
        }

        [ConfigurationProperty(EMAIL_ADDRESS)]
        public virtual string EmailAddress
        {
            get { return (string)this[EMAIL_ADDRESS]; }
            set { this[EMAIL_ADDRESS] = value; }
        }

        [ConfigurationProperty(MOBILEPHONE_NUMBER)]
        public virtual string MobilephoneNumber
        {
            get { return (string)this[MOBILEPHONE_NUMBER]; }
            set { this[MOBILEPHONE_NUMBER] = value; }
        }

        [ConfigurationProperty(TELEPHONE_NUMBER)]
        public virtual string TelephoneNumber
        {
            get { return (string)this[TELEPHONE_NUMBER]; }
            set { this[TELEPHONE_NUMBER] = value; }
        }

        [ConfigurationProperty(MONEY)]
        public virtual string Money
        {
            get { return (string)this[MONEY]; }
            set { this[MONEY] = value; }
        }

        [ConfigurationProperty(INTEGER_NUMBER)]
        public virtual string IntegerNumber
        {
            get { return (string)this[INTEGER_NUMBER]; }
            set { this[INTEGER_NUMBER] = value; }
        }

        [ConfigurationProperty(DECIMAL_NUMBER)]
        public virtual string DecimalNumber
        {
            get { return (string)this[DECIMAL_NUMBER]; }
            set { this[DECIMAL_NUMBER] = value; }
        }

        [ConfigurationProperty(CITIZEN_NUMBER)]
        public virtual string CitizenNumber
        {
            get { return (string)this[CITIZEN_NUMBER]; }
            set { this[CITIZEN_NUMBER] = value; }
        }

        [ConfigurationProperty(PASSPORT_NUMBER)]
        public virtual string PassportNumber
        {
            get { return (string)this[PASSPORT_NUMBER]; }
            set { this[PASSPORT_NUMBER] = value; }
        }

        [ConfigurationProperty(POSTCODE)]
        public virtual string Postcode
        {
            get { return (string)this[POSTCODE]; }
            set { this[POSTCODE] = value; }
        }

        [ConfigurationProperty(THAI_ALPHABET)]
        public virtual string ThaiAlphabet
        {
            get { return (string)this[THAI_ALPHABET]; }
            set { this[THAI_ALPHABET] = value; }
        }

        [ConfigurationProperty(ENGLISH_ALPHABET)]
        public virtual string EnglishAlphabet
        {
            get { return (string)this[ENGLISH_ALPHABET]; }
            set { this[ENGLISH_ALPHABET] = value; }
        }

        [ConfigurationProperty(PASSWORD)]
        public virtual string Password
        {
            get { return (string)this[PASSWORD]; }
            set { this[PASSWORD] = value; }
        }

        [ConfigurationProperty(PIN)]
        public virtual string Pin
        {
            get { return (string)this[PIN]; }
            set { this[PIN] = value; }
        }


        [ConfigurationProperty(POSITIVE_INTEGER)]
        public virtual string PositiveInteger
        {
            get { return (string)this[POSITIVE_INTEGER]; }
            set { this[POSITIVE_INTEGER] = value; }
        }

        [ConfigurationProperty(WEBSITE_URL)]
        public virtual string WebsiteUrl
        {
            get { return (string)this[WEBSITE_URL]; }
            set { this[WEBSITE_URL] = value; }
        }
        #endregion
    }
}