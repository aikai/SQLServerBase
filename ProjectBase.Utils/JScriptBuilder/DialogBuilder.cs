using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ProjectBase.Utils.JScriptBuilder
{
    public class DialogBuilder : JavaScriptBuilder
    {
        #region Fields
        protected int width = 800;
        protected int height = 600;
        #endregion

        #region Properties
        public virtual string Url { get; set; }

        public virtual int Width
        {
            get { return width; }
            set { width = value; }
        }

        public virtual int Height
        {
            get { return height; }
            set { height = value; }
        }

        public virtual string PredialogScript { protected get; set; }
        public virtual string PostdialogScript { protected get; set; }
        #endregion

        protected override string Build()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Url))
            {
                sb.AppendFormat(@"{4}window.showModalDialog('{0}', this,'dialogHeight: {1}px; dialogWidth: {2}px;');{3}",
                    Url, Height, Width, PostdialogScript, PredialogScript);
            }

            return sb.ToString();
        }
    }
}