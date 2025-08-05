using Lab_13;

namespace Lab_13_Tests
{
    [TestClass]
    public sealed class Lab_13_Tests
    {
        [TestMethod]
        public void InconsistentLimits()
        {
            try
            {
                LimitedStringLoader loader = new("qwer", "erty", 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var value in ex.Data.Values)
                    Console.WriteLine(value.ToString());
            }
        }

        [TestMethod]
        public void FileNotFound()
        {
            LimitedStringLoader loader = new("qwe", "rty", 0);

            try
            {
                loader.Load("qwerty");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.FileName);
            }
        }

        [TestMethod]
        public void DataNotLoaded()
        {
            LimitedStringLoader loader = new("qwe", "rty", 0);

            try
            {
                var data = loader.Strings;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TooManyProhibitedLines()
        {
            List<string> strings = [
                "A 100 100",
                "B 200 200",
                "B 200 200"];
            string file = CreateTestFile(strings);

            LimitedStringLoader loader = new("B", "", 1);
            try
            {
                loader.Load(file);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DeleteTestFile(file);
            }
        }

        [TestMethod]
        public void WrongStartingSymbol()
        {
            List<string> strings = [
                "A 100 100",
                "B 200 200",
                "B 200 200"];
            string file = CreateTestFile(strings);

            LimitedStringLoader loader = new("", "B", 1);
            try
            {
                loader.Load(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DeleteTestFile(file);
            }
        }

        [TestMethod]
        public void IncorrectString()
        {
            List<string> strings = [
                "A 100 100",
                "B 200 200",
                "b 200 200"];
            string file = CreateTestFile(strings);

            LimitedStringLoader loader = new("", "B", 1);
            try
            {
                loader.Load(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DeleteTestFile(file);
            }
        }

        public string CreateTestFile(IEnumerable<string> strings)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "test.txt");

            File.WriteAllLines(path, strings);

            return path;
        }

        public void DeleteTestFile(string filePath) =>
            File.Delete(filePath);
    }
}
