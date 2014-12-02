using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Components;
using ProjectBase.Utils.Commons;

namespace ProjectBase.Utils
{
    public interface IComponentFactory
    {
        IDateTimeInterval CreateDateTimeInterval();
        IValueValidation CreateDateTime();
        IValueValidation CreateEmailAddress();
        IValueValidation CreateIdentityNumber();
        IValueValidation CreateTelephoneNumber();
        IValueValidation CreateMobilephoneNumber();
        IValueValidation CreatePostCode();
        IValidationExpression CreateValidationExpression();
        IFormat CreateFormat();
        // Commons Entity
        IEntityBase CreateEntityBase();
        IMasterEntity CreateMasterEntity();
        IMultiLanguageEntity CreateMultiLanguageEntity();
        IUserAccount CreateUserAccount();
        IUtility CreateUtility();
        ISendEmail CreateSendEmail();
    }

    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations

    #endregion
}