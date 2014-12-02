using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    /// <summary>
    /// Provides an interface for retrieving entity objects
    /// </summary>
    public interface IEntityFactory
    {        
        IProvince CreateProvince();
        IAmphoe CreateAmphoe();
        ITambol CreateTambol();
        IAddress CreateAddress();
        IHrPosition CreateHrPosition();
        IHrDepart CreateHrDepart();
        IUaeProjectManage CreateUaeProjectManage();
    }

    // There's no need to declare each of the entity interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
    
    #endregion
}
