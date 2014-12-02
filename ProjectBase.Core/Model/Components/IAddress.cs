using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IAddress
    {
        string HouseNo { get; set; }
        string Moo { get; set; }
        string Soi { get; set; }
        string Road { get; set; }

        ITambol Tambol { get; set; }
        IAmphoe Amphoe { get; set; }
        IProvince Province { get; set; }

        IValueValidation PostCode { get; set; }
    }
}