using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dictionaries
{
    [Serializable]
    public class AllSections
    {
        private XmlSerializer formatter;
        public List<Section> sections { get; set; }

        public AllSections()
        {
            formatter = new XmlSerializer(typeof(AllSections));
            sections = new List<Section>();
        }

        public void SerializeXml(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Truncate))
                {
                    formatter.Serialize(fs, this);
                }
            }
            catch
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }
            }
        }

        public void DeserializeXml(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    var newSection = (AllSections)formatter.Deserialize(fs);
                    foreach (var item in newSection.sections)
                        sections.Add(new Section(item.name, item.words));
                }
            }
            catch { Console.WriteLine("Файл удалён, или не был создан!"); }
        }
    }
}
