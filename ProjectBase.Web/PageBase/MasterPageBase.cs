using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.Context;
using Spring.Context.Support;
using ProjectBase.Core;
using ProjectBase.Web.Resources;
using ProjectBase.Utils;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Adapter;

namespace ProjectBase.Web.PageBase
{
    public abstract class MasterPageBase : System.Web.UI.MasterPage
    {
        protected virtual void Page_Init(object sender, EventArgs e)
        {

        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {

        }

        protected IUtility Utility
        {
            get { return ComponentFactory.CreateUtility(); }
        }

        protected IApplicationContext ApplicationContext
        {
            get { return ContextRegistry.GetContext(); }
        }

        /// <summary>
        /// Exposes accessor for the <see cref="IDaoFactory" /> used by all pages.
        /// </summary>
        protected IDaoFactory DaoFactory
        {
            get { return (IDaoFactory)ApplicationContext[Globals.DaoFactory]; }
        }

        /// <summary>
        /// Exposes accessor for the <see cref="IEntityFactory" /> used by all pages.
        /// </summary>
        protected IEntityFactory EntityFactory
        {
            get { return (IEntityFactory)ApplicationContext[Globals.EntityFactory]; }
        }

        /// <summary>
        /// Exposes accessor for the <see cref="IComponentFactory" /> used by all pages.
        /// </summary>
        protected IComponentFactory ComponentFactory
        {
            get { return (IComponentFactory)ApplicationContext[Globals.ComponentFactory]; }
        }
    }
}