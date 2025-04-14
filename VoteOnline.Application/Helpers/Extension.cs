using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VoteOnline.Application.Helpers
{
    public class Extension
    {
        public static string SerializeListToXml<T>(List<T> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, list);
                return textWriter.ToString();
            }
        }
    }
}
