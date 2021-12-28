using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    public class SerializeXML<T> : DataFilling<T>
    {
        XmlSerializer xmlformatter;


        public SerializeXML(string dataPath) : base(dataPath)
        {
            xmlformatter = new XmlSerializer(typeof(T));
        }
        public override bool Serialize(T obj)
        {
            if (IsHere() == false) { return false; }
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                fs.Dispose();
                fs.Close();
            }

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                xmlformatter.Serialize(fs, obj);

                fs.Dispose();
                fs.Close();
            }

            return true;
        }
        public override T Deserialize()
        {
            if (IsHere() == false) { throw new SerializationException("Десеріалізація неможлива, немає файлу."); }

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                return (T)xmlformatter.Deserialize(fs);
            }
        }

    }
}
