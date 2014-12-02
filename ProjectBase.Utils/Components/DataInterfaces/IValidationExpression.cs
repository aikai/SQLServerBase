using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Utils.Components
{
    public interface IValidationExpression
    {
        #region My properties
        string Time { get; set; }
        string DateTime { get; set; }
        string EmailAddress { get; set; }
        string MobilephoneNumber { get; set; }
        string TelephoneNumber { get; set; }
        string Money { get; set; }
        string IntegerNumber { get; set; }
        string DecimalNumber { get; set; }
        string CitizenNumber { get; set; }
        string PassportNumber { get; set; }
        string Postcode { get; set; }
        string ThaiAlphabet { get; set; }
        string EnglishAlphabet { get; set; }
        string Password { get; set; }
        string Pin { get; set; }
        string PositiveInteger { get; set; }
        string WebsiteUrl { get; set; }
        #endregion
    }
}
