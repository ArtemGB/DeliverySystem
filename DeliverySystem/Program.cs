using System;
using DeliverySystem.DeliveryCore.Data;
using DeliverySystem.DeliveryCore.Management;

namespace DeliverySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Car Car = new Car("Car", 60, 700, 5);
            Console.WriteLine("{0}, {1}, {2}, {3}", Car.Name, Car.Speed, Car.MaxDistance, Car.CarryingCapacity);
            Console.WriteLine($"{Car.ID}");
            Car.AddProduct(new Product("pr"));
            Car.AddProduct(new Product("pr2"));
            foreach (var item in Car.Cargo)
            {
                Console.WriteLine(item.Name);
            }
            ClientManager manager = new ClientManager();
            manager.AddClient(new Client("cl", "dw", "awdqw", '7', "9162506593"));
            manager.AddClient(new Client("cdwel", "deew", "awdqw", '7', "9162506593"));
            manager.AddClient(new Client("cldew", "ddw", "awdqw", '7', "9162506593"));
            Console.WriteLine("---------------------");
            foreach (var item in manager.Clients)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"Name:{item.Value.Name} SecName:{item.Value.SecondName}");
            }
            manager.RemoveClient(1);
            Console.WriteLine("---------------------");
            foreach (var item in manager.Clients)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"Name:{item.Value.Name} SecName:{item.Value.SecondName}");
            }
        }
    }
}
