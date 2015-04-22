using System;
using System.Configuration;
using System.Xml.Linq;

namespace AngularWebApiApp.Data
{
    public class EnvironmentConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("EnvironmentConfig", IsRequired = true)]
        public string EnvironmentConfig
        {
            get { return (string)base["EnvironmentConfig"]; }
            set { base["EnvironmentConfig"] = value; }
        }

        XElement _ConnectionString;
        public XElement ConnectionString
        {
            get { return _ConnectionString; }
        }

        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            if (elementName == "ConnectionString")
            {
                _ConnectionString = (XElement)XElement.ReadFrom(reader);
                return true;
            }
            else
                return base.OnDeserializeUnrecognizedElement(elementName, reader);
        }
    }
}
