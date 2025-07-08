//Лабораторная работа №9. Классы и объекты
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=19162


using Lab_09;
Action<string> WriteL = Console.WriteLine;
Func<string?> ReadL = Console.ReadLine;

ProductDatabase mainProductBase = new();
mainProductBase.AddProduct(new Product("Donut", 2));
mainProductBase.AddProduct(new Product("Beer Daff", 5));
mainProductBase.AddProduct(new Product("Pizza", 12));
mainProductBase.AddProduct(new Product("Bacon", 4));

string? name;
do
{
    WriteL("Добавляем покупателя. Введите имя:");
    name = ReadL();
}
while (string.IsNullOrEmpty(name));

//Не проверяю на Null, т.к. покупатель может отказаться сообщать адрес
//конструктор Customer выполнит проверку на ноль и подставит пустую строку при необходимости
WriteL("Введите адрес:");
string? address = ReadL();

double discount;
string? input;
do
{
    WriteL("Введите скидку для этого покупателя в процентах (от 0 до 100):");
    input = ReadL();
}
while (string.IsNullOrEmpty(input) || 
        !int.TryParse(input, out int result) || 
        result < 0 || 
        result > 100);
discount = double.Parse(input) / 100;

Customer customer = new(name, address, discount);
//WriteL(customer.ToString());

Order order = new(10001, customer);
WriteL(Environment.NewLine + "Продукты в базе данных:");
WriteL(mainProductBase.ToString());

do
{
    WriteL("Добавить продукт в заказ (введите код продукта) или завершить создание заказа (введите N)?");
    input = ReadL();
    if (mainProductBase.TryGetProductByCode(input, out Product product))
    {
        Console.Write(product.ToString());
        int qauntity;
        do
        {
            WriteL("Добавить единиц:");
            input = ReadL();
            
        }
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out qauntity) || qauntity < 0);
        order.AddOrderLine(product, qauntity);
    }
    else if (input != "N" && input != "n")
        WriteL($"Продукт с кодом {input} не найден");
}
while(input != "N" && input != "n");

WriteL(Environment.NewLine + "Полный заказ:");
WriteL(order.ToString());