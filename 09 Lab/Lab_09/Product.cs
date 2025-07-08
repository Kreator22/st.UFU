using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name ?? throw new 
                ArgumentNullException(nameof(name), "У продукта должно быть название");
            Price = price;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Price: " + Price);
            return sb.ToString();
        }
    }
}
