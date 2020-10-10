using System;
using DeliverySystem.DeliveryCore.Data;
using DeliverySystem.DeliveryCore.Management;

namespace DeliverySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Car TestCar = new Car("Car", 60, 700, 5);
            Console.WriteLine("{0}, {1}, {2}, {3}", TestCar.Name, TestCar.Speed, TestCar.MaxDistance, TestCar.CarryingCapacity);
            Console.WriteLine($"{TestCar.ID}");
            TestCar.AddProduct(new Product("Сайга-9", new Demensions(1,0.1,0.2)));
            TestCar.AddProduct(new Product("TR3", new Demensions(1, 0.1, 0.2)));
            //TestCar.Cargo[0] = new Product("dfewf");
            foreach (var item in TestCar.Cargo)
            {
                Console.WriteLine(item.Name);
            }
            ClientManager manager = new ClientManager();
            Console.WriteLine("---------------------");
            foreach (var item in manager.Clients)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"Name:{item.Value.Name} SecName:{item.Value.SecondName}");
            }
            Console.WriteLine("---------------------");
            foreach (var item in manager.Clients)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"Name:{item.Value.Name} SecName:{item.Value.SecondName}");
            }
        }
    }
}
