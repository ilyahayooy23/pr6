using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practical_6
{
    internal class SerialandDeserial
    {
        public static void JsonSerial(List<wwf> figure, string path)
        {
            string json = JsonConvert.SerializeObject(figure);
            File.WriteAllText(path, json);
        }
        public static void JsonDeserial(string path)
        {
            string js = File.ReadAllText(path);
            List<wwf> result = JsonConvert.DeserializeObject<List<wwf>>(js);
        }
        public static void XmlSerial(List<wwf> figure, string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<wwf>));
            using (FileStream f = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(f, figure);
            }
        }
        public static void XmlDeserial(string path)
        {
            wwf tekst;
            XmlSerializer xml = new XmlSerializer(typeof(List<wwf>));
            using (FileStream ff = new FileStream(path, FileMode.Open))
            {
                tekst = (wwf)xml.Deserialize(ff);
            }
        }
    }
}