using System;
using DeliverySystem.Data;

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
        }
    }
}
