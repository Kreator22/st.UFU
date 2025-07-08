using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    public class Order
    {
        public int OrderNumber { get; private set; }
        public Customer Customer { get; private set; }
        public decimal Discount { get => (decimal)Customer.Discount; }
        public decimal TotalPrice {
            get => orderLines
                .Select(orderLine => orderLine.TotalPrice(Discount))
                .Sum();}
        List<OrderLine> orderLines = new();

        public Order(int orderNumber, Customer customer)
        {
            Customer = customer ?? throw new 
                ArgumentNullException(nameof(customer), "У заказа должен быть покупатель");
            OrderNumber = orderNumber;
        }

        public void AddOrderLine(Product product, int quantity) =>
            orderLines.Add(new OrderLine(product, (decimal)Customer.Discount, quantity));
       
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Customer.ToString());
            foreach (var line in orderLines)
                sb.AppendLine(line.ToString());
            sb.AppendLine("Total order price = " + TotalPrice);
            return sb.ToString();
        }
    }
}
