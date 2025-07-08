using Lab_09;

namespace Lab_09_Tests
{
    [TestClass]
    public sealed class Lab_09_Tests
    {
        [TestMethod]
        public void Customer()
        {
            Customer customer = new("Homer", "Springfield", 0.1);
            Console.WriteLine(customer);

            customer = new("Karl");
            Console.WriteLine(customer);
        }

        [TestMethod]
        public void Products()
        {
            foreach (var product in GetProducts())
                Console.WriteLine(product);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new();
            products.Add(new Product("Donut", 2));
            products.Add(new Product("Beer Daff", 5));
            products.Add(new Product("Pizza", 12));

            return products;
        }

        [TestMethod]
        public void ProductDatabase()
        {
            ProductDatabase database = new();
            database.AddProduct(new Product("Bacon", 4));
            database.AddProduct(GetProducts());
            Console.WriteLine(database);
        }

        [TestMethod]
        public void OrderLines()
        {
            var products = GetProducts();
            List<OrderLine> orderLines = new();

            int i = 4;
            foreach(var product in products)
                orderLines.Add(new OrderLine(product, i--));

            foreach (var orderLine in orderLines)
            {
                Console.Write(orderLine);
                Console.WriteLine
                    ("Price with discount = " + orderLine.TotalPrice(0.1m) + Environment.NewLine);
            }
                


        }
    }
}
