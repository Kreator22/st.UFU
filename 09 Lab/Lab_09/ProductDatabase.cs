using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    [Serializable]
    [DataContract]
    public class ProductDatabase
    {
        [DataMember]
        public Dictionary<string, Product> database { get; private set; }
        public ProductDatabase() =>
            database = new();
        public ProductDatabase(IEnumerable<Product> products) : this() =>
            AddProduct(products);


        public void AddProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product, nameof(product));

            string productCode;
            do
                productCode = GenerateCode();
            while (database.ContainsKey(productCode));

            database.Add(productCode, product);
        }

        public void AddProduct(IEnumerable<Product> products)
        {
            foreach (var product in products)
                AddProduct(product);
        }

        public bool TryGetProductByCode(string code, out Product product) =>
            database.TryGetValue(code, out product);

        private string GenerateCode() =>
            Convert.ToChar(Random.Shared.Next('A', 'Z')) +
            Random.Shared.Next(0, 999).ToString().PadLeft(3,'0');

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach(var pair in database)
            {
                sb.AppendLine(pair.Key);
                sb.AppendLine(pair.Value.ToString());
            }
            return sb.ToString();
        }


    }
}
