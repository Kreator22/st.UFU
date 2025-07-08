using Lab_09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HW_08
{
    public static class XML
    {
        public static ProductDatabase testBase = new([
            new Product("Bread", 2.5m),
            new Product("Milk", 4),
            new Product("Onion", 0.99m)
            ]);

        /// <summary>
        /// Создаёт сериализатор настроенный для сериализации объектов ProductDatabase
        /// </summary>
        /// <returns>Экземпляр сериализатора</returns>
        static private DataContractSerializer GetProductDatabaseSerializer()
        {
            //Задаём для сериализируемых типов атрибуты [DataContract] и [DataMember].
            //На основе атрибутов сериализатор составляет контракты,
            //согласно которым будет будет происходить сериализация экземпляров типов.
            //Указываем сериализатору перечень типов (помимо корневого) для которых надо составить контракты 
            //и быть готовым сериализировать экземпляры.
            Type[] knownTypes = [typeof(Product)];
            //Создаём экземпляр сериализатора.
            return new DataContractSerializer(typeof(ProductDatabase), knownTypes);
        }


        public static void SerializeXML(ProductDatabase productDatabase, string path)
        {
            string? directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException
                    ("Директория не найдена" + Environment.NewLine + directory);


            var serializer = GetProductDatabaseSerializer();


            //Создаём поток
            using (FileStream fs = new FileStream(path, FileMode.Create))
                //Для потока создаём XmlDictionaryWriter, который умеет писать XML в поток
                using (XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateTextWriter(fs, Encoding.UTF8))
                    //А через него пишем с помощью сериализатора DataContractSerializer
                    serializer.WriteObject(xdw, testBase);
        }
        
        public static ProductDatabase DeSerializeXML(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден" + Environment.NewLine, path);

            var serializer = GetProductDatabaseSerializer();
            ProductDatabase database;
            //Создаём поток
            using (FileStream fs = new FileStream(path, FileMode.Open))
            //Для потока создаём XmlDictionaryReader, который умеет читать XML из потока
            using (XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                //А через него читаем и парсим объект с помощью (де)сериализатора DataContractSerializer
                database = (ProductDatabase)serializer.ReadObject(xdr);

            return database;
        }

    }
}
