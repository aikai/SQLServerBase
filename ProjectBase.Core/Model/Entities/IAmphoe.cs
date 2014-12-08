using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IAmphoe
    {
        Guid Id { get; set; }
        string ThaiName { get; set; }
        string EnglishName { get; set; }
        string CreateBy { get; set; }
        IValueValidation CreateDate { get; set; }
        string UpdateBy { get; set; }
        IValueValidation UpdateDate { get; set; }

        IProvince Province { get; set; }

        bool Equals(object obj);
        bool Equals(IAmphoe obj);
        int GetHashCode();
    }
}
