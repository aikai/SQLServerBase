using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ProjectBase.Data
{
    public class Config : ConfigurationSection
    {
        public Config()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [ConfigurationProperty("ConnectionName", DefaultValue = "Conn")]
        public string ConnectionName
        {
            get { return (string)base["ConnectionName"]; }
            set { base["ConnectionName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[this.ConnectionName].ConnectionString;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
