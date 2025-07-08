using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    public class OrderLine
    {
        public Product Product { get; private set; }
        public decimal Discount { get; private set; }
        public int Quantity { get; private set; }
        
        public OrderLine(Product product, decimal discount = 0, int quantity = 1)
        {
            Product = product ?? throw new 
                ArgumentNullException(nameof(product), "В строчке заказа должен быть заказываемый продукт");
            Discount = discount;
            Quantity = quantity;
        }

        public decimal TotalPrice() =>
            Product.Price * Quantity * (1 - Discount);

        public decimal TotalPrice(decimal discount = 0) =>
            Product.Price * Quantity * (1 - discount);

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Product.ToString());
            sb.AppendLine("Quantity = " + Quantity);
            sb.AppendLine("TotalPrice = " + TotalPrice());
            return sb.ToString();
        }
    }
}
