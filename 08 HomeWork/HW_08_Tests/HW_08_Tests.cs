using Lab_09;

namespace HW_08_Tests
{
    [TestClass]
    public sealed class HW_08_Tests
    {
        [TestMethod]
        public void SerializeXML()
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "SOAP.dat";
            string path = Path.Combine(directory, fileName);
            Console.WriteLine(path);

            HW_08.XML.SerializeXML(HW_08.XML.testBase, path);
        }

        [TestMethod]
        public void DeSerializeXML()
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "SOAP.dat";
            string path = Path.Combine(directory, fileName);
            Console.WriteLine(path);

            ProductDatabase database = HW_08.XML.DeSerializeXML(path);
            Console.WriteLine(database);
        }
    }
}
