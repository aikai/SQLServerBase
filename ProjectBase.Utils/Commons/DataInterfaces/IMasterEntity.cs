using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Components;

namespace ProjectBase.Utils.Commons
{
    public interface IMasterEntity : IEntityBase
    {
        //#region IIdentification Members
        //Guid Id { get; set; }
        //#endregion

        //#region IMaster Members
        //string Name { get; set; }
        //string ShortName { get; set; }
        //#endregion

        //#region IMultiLanguageEntity Members
        //string ThaiName { get; set; }
        //string EnglishName { get; set; }
        //#endregion

        //#region ITransactionLog Members
        //IUserAccount CreateBy { get; set; }
        //IValueValidation CreateDate { get; set; }
        //IUserAccount UpdateBy { get; set; }
        //IValueValidation UpdateDate { get; set; }
        //#endregion
    }
}
