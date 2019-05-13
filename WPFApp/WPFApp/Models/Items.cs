using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WPFApp
{

    public class Items
    {
        [XmlElement("Item")]
        public List<Item> Item { get; set; }
    }
}
