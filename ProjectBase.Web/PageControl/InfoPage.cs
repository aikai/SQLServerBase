using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ProjectBase.Web.PageBase;
using ProjectBase.Utils.Adapter;
using ProjectBase.Web.Resources;
using ProjectBase.Utils.JScriptBuilder;
using ProjectBase.Core.Model;

namespace ProjectBase.Web.PageControl
{
    public abstract class InfoPage : BasePage
    {
        protected virtual void OnUpdateSucceed()
        {
            JavaScriptBuilder.Build(new AlertBuilder(Globals.Update_succeed));
        }

        protected virtual void OnSaveSucceed()
        {
            JavaScriptBuilder.Build(new AlertBuilder(Globals.Save_succeed));
            //ClearState();
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;

                Load_Init();

                if (Mode.New == Mode)
                {
                    InitNewMode();
                }
                else if (Mode.Edit == Mode)
                {
                    InitEditMode();
                }
            }
            catch (Exception ex)
            {
                var message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                JavaScriptBuilder.Build(new AlertBuilder(message));
            }
        }

        //protected virtual void OnClose(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        JavaScriptBuilder.Build(new AlertBuilder(ex.Message));
        //    }
        //}

        //protected virtual string ReloadButtonId
        //{
        //    get { return "btnReload"; }
        //}

        //protected virtual void Close()
        //{
        //    var script = string.Format("this.parent.document.all.{0}.click();", ReloadButtonId);
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", script, true);
        //}

        //protected virtual void Close(string reloadButtonId)
        //{
        //    var script = string.Format("this.parent.document.all.{0}.click();", reloadButtonId);
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", script, true);
        //}

        protected virtual void Load_Init() { }

        protected virtual void InitNewMode() { }

        protected virtual void InitEditMode() { }
    }
}