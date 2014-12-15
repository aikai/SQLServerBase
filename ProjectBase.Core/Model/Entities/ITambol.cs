using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ITambol
    {
        Guid Id { get; set; }
        string ThaiName { get; set; }
        string EnglishName { get; set; }
        IValueValidation PostCode { get; set; }
        string CreateBy { get; set; }
        DateTime CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime UpdateDate { get; set; }

        IAmphoe Amphoe { get; set; }

        bool Equals(object obj);
        bool Equals(ITambol obj);
        int GetHashCode();
    }
}
