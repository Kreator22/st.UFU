using System.Runtime.Serialization.Formatters.Binary;

//Бинарную сериализацию больше нельзя использовать
//https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/binaryformatter-security-guide

using Lab_09;

namespace HW_08
{
    /*static class Binary
    {
        static void SerializeBinary(ProductDatabase productDatabase, string path)
        {
            string directory = Path.GetFullPath(path);
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException("Указаная директория не найдена" +
                    Environment.NewLine + directory);

            BinaryFormatter formatter = new();
            using (FileStream fs = File.OpenWrite(path))
                formatter.Serialize(fs, productDatabase);
        }

        static ProductDatabase DeserializeBinary(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл для десериализации не найден", path);

            BinaryFormatter formatter = new();
            ProductDatabase database;
            using (FileStream fs = File.OpenRead(path))
                database = (ProductDatabase)formatter.Deserialize(fs);

            return database;
        }
    }*/
}
