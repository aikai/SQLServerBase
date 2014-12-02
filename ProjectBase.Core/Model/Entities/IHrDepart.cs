using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IHrDepart
    {
        long Id { get; set; }
        string DeptTname { get; set; }
        string DeptEname { get; set; }
        System.Nullable<long> DeptIdx { get; set; }
        System.Nullable<long> DeptOrder { get; set; }
        string DeptGroup { get; set; }
    }
}
