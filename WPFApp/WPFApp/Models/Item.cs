using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WPFApp
{
    public class Item
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }


        [XmlElement("Quantity")]
        public string Quantity { get; set; }


        [XmlElement("Price")]
        public string Price { get; set; }
    }
}
