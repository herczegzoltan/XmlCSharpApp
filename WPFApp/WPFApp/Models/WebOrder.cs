using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WPFApp
{
    [XmlRoot("WebOrder")]
    public class WebOrder
    {

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("Customer")]
        public string Customer { get; set; }
        
        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Items")]
        public List<Items> Items { get; set; }
    }
    
}
