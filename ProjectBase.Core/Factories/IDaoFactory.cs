using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    /// <summary>
    /// Provides an interface for retrieving DAO objects
    /// </summary>
    public interface IDaoFactory
    {
        IProvinceDao GetProvinceDao();
        IAmphoeDao GetAmphoeDao();
        ITambolDao GetTambolDao();
        IHrPositionDao GetHrPositionDao();
    }

    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
    public interface IProvinceDao : IDao<IProvince> { }
    public interface IAmphoeDao : IDao<IAmphoe> { }
    public interface ITambolDao : IDao<ITambol> { }
    public interface IHrPositionDao : IDao<IHrPosition> { }
    #endregion
}
