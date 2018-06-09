using Class4Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace 序列化与反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String filePath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(filePath);

            List<Programmer> list = new List<Programmer>();
            list.Add(new Programmer("Wang", true, "C#"));
            list.Add(new Programmer("Coder01", true, "C++"));
            list.Add(new Programmer("Coder02", false, "C"));
            // 二进制序列化
            String fileName = String.Format("{0}\\{1}", filePath, "programmer.dat");
            BinaryFormatter binFormat = new BinaryFormatter();
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            binFormat.Serialize(fStream, list);
            // 二进制反序列化
            list.Clear();
            fStream.Position = 0;
            list = (List<Programmer>)(binFormat.Deserialize(fStream));
            if(list.Count>0)
            {
                Console.WriteLine("********二进制反序列化*********");
                foreach(Programmer p in list)
                {
                    Console.WriteLine(p);
                }
            }

            // SOAP序列化
            String soapFileName = String.Format("{0}\\{1}", filePath, "programmer_soap.xml");
            // 没有找到SOAP包

            // xml序列化
            XmlSerializer xmlFormat = new XmlSerializer(list.GetType());
            String xmlFileName = String.Format("{0}\\{1}", filePath, "programmer_xml.xml");
            fStream = new FileStream(xmlFileName, FileMode.Create, FileAccess.ReadWrite);
            xmlFormat.Serialize(fStream, list);
            // xml反序列化
            List<Programmer> xmlList = new List<Programmer>();
            fStream.Position = 0;
            xmlList = (List<Programmer>)(xmlFormat.Deserialize(fStream));
            if(xmlList.Count >0)
            {
                Console.WriteLine("###############XML反序列化##################");
                foreach(Programmer p in xmlList)
                {
                    Console.WriteLine(p);
                }
            }

            Console.ReadKey();
        }
    }
}
