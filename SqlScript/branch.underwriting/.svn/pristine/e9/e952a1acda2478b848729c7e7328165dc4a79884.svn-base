using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WSVirtualOffice
{
    public class Settings : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ReturnList), AddItemName = "Return")]
        public ReturnList Elements
        {
            get { return (ReturnList)this[""]; }
        }

        public class ReturnTypes : ConfigurationElement
        {
            [ConfigurationProperty("Start", DefaultValue = "1", IsRequired = false)]
            public int Start
            {
                get
                {
                    return (int)this["Start"];
                }
                set
                {
                    this["Start"] = value;
                }
            }
            [ConfigurationProperty("End", DefaultValue = "1", IsRequired = false)]
            public int End
            {
                get
                {
                    return (int)this["End"];
                }
                set
                {
                    this["End"] = value;
                }
            }
            [ConfigurationProperty("Percent", DefaultValue = "0.00", IsRequired = false)]
            public decimal Percent
            {
                get
                {
                    return (decimal)this["Percent"];
                }
                set
                {
                    this["Percent"] = value;
                }
            }
        }
    }

    public class ReturnList : ConfigurationElementCollection, IEnumerable<Settings.ReturnTypes>
    {
        private readonly List<Settings.ReturnTypes> elements;

        public ReturnList()
        {
            this.elements = new List<Settings.ReturnTypes>();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            var element = new Settings.ReturnTypes();
            this.elements.Add(element);
            return element;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Settings.ReturnTypes)element);
        }

        public new IEnumerator<Settings.ReturnTypes> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }
    }
}