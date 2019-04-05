
namespace CheatSheets.Extensions
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;


    public class XmlExtensions
    {
        
        public static T DeserializeXml<T>(string obj)
        {
            var serialiser = new XmlSerializer(typeof(T));
            byte[] msgByteArray = Encoding.UTF8.GetBytes(obj);
            var msgStream = new MemoryStream(msgByteArray);
            return (T)serialiser.Deserialize(msgStream);
        }

        public static string XmlEscape(string unescaped)
        {
            if (string.IsNullOrEmpty(unescaped)) return "";
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateElement("root");
            node.InnerText = unescaped;
            return node.InnerXml;
        }


        public static string XmlUnescape(string escaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateElement("root");
            node.InnerXml = escaped;
            return node.InnerText;
        }

    }
}
