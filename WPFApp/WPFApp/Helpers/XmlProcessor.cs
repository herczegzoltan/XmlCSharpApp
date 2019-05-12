using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFApp.Helpers
{
    public class XmlProcessor
    {
        public static WPFApp.WebOrder LoadXml(string path)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(WebOrder));

            using (FileStream fileStream = new FileStream(@"" + path, FileMode.Open))
            {
                WebOrder result = (WebOrder)serializer.Deserialize(fileStream);

                return result;

              
            }

        }
    }
}
