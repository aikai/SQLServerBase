using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectBase.Web.PageBase;
using ProjectBase.Utils.Adapter;
using ProjectBase.Web.Resources;
using ProjectBase.Utils.JScriptBuilder;
using ProjectBase.Core.Model;

namespace ProjectBase.Web.PageControl
{
    public delegate void Delete(string[] ids);

    public abstract class ListPage : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Load_Init();
                    Search();
                }
            }
            catch (Exception ex)
            {
                var message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                JavaScriptBuilder.Build(new AlertBuilder(message));
            }
        }

        protected virtual void Delete(Delete delete)
        {
            var value = DeleteId;

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception(Globals.No_data_to_delete);
            }

            var ids = value.Split(',');

            if (null == ids || 1 > ids.Length)
            {
                throw new Exception(Globals.Invalid_id_to_delete);
            }

            delete(ids);

            OnDeleteSucceed();
            Search();
        }

        protected virtual void OnDeleteSucceed()
        {
            JavaScriptBuilder.Build(new AlertBuilder(Globals.Delete_succeed));
            Search();
        }

        protected virtual string InfoPageUrl
        {
            get { return null; }
        }

        protected virtual string BuildEditUrl(object id)
        {
            return string.Format("{0}?{1}={2}", InfoPageUrl, QueryStringAdapter.Name.EditId, id);
        }

        protected virtual string PrintPageUrl
        {
            get { return null; }
        }

        protected virtual string BuildPrintUrl(object id)
        {
            return string.Format("{0}?{1}={2}", PrintPageUrl, QueryStringAdapter.Name.PrintId, id);
        }

        protected virtual string DeleteId
        {
            get { return null; }
        }

        protected virtual void Search() { }

        protected virtual void Load_Init() { }
    }
}