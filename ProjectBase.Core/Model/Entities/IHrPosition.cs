using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IHrPosition
    {
        long Id { get; set; }
        string PsTname { get; set; }
        string PsEname { get; set; }
        string PsComment { get; set; }
        string PsMn { get; set; }
        string PsIden { get; set; }
    }
}
