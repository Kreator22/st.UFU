using System.Text;

namespace Lab_09
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public double Discount { get; private set; }

        public Customer(string name, string? address = "", double discount = 0)
        {
            Name = !string.IsNullOrEmpty(name) ? name : 
                throw new ArgumentException("У покупателя должно быть имя", nameof(name));
            Address = address ?? "";
            if (discount < 0 || discount > 1)
                throw new ArgumentOutOfRangeException
                    (nameof(discount), "Скидка должна быть в диапазоне [0, 1]");
            else
                Discount = discount;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Address: " + Address);
            sb.AppendLine("Discount: " + Discount);
            return sb.ToString();
        }
    }
}
