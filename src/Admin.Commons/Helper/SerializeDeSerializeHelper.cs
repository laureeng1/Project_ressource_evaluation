using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Admin.Common.Helper
{
      public class SerializeDeSerializeHelper<T>
    {
          public SerializeDeSerializeHelper()
        {
            //Default constructor
        }
        #region XML Serialization
        private static void ToFile(string path, T o)
        {
            TextWriter textWriter;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (textWriter = new StreamWriter(path))
                {
                    serializer.Serialize(textWriter, o);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static MemoryStream ToMemory(T o)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(memoryStream, o);
                return memoryStream;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static string ToXml(T o)
        {
            string returnVal = string.Empty;

            using (MemoryStream memoryStream = ToMemory(o))
            {
                memoryStream.Position = 0;
                using (StreamReader sr = new StreamReader(memoryStream))
                {
                    returnVal = sr.ReadToEnd();
                }
            }
            return returnVal;
        }
        #endregion

        #region XML De-Serialization

        private static T FromFile(string path)
        {
            T o;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (TextReader textReader = new StreamReader(path))
                {
                    o = (T)serializer.Deserialize(textReader);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return o;
        }

        public static T FromXml(string xmlString)
        {
            T o;
            try
            {
                StringReader stringReader = new StringReader(xmlString);
                XmlTextReader textReader = new XmlTextReader(stringReader);
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                o = (T)serializer.Deserialize(textReader);
                stringReader.Close();
                textReader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return o;
        }
        #endregion
    }

}
