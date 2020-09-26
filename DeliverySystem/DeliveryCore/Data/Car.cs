using System;
using System.Collections.Generic;
using System.Threading;

namespace DeliverySystem.DeliveryCore.Data
{
    /// <summary>
    /// Грузовая машина.
    /// </summary>
    class Car : Deliveryman
    {
        private static int globalID;
        private readonly int id;
        public override int ID => id;

        private int speed;
        public override int Speed
        {
            get => speed;
            protected set
            {
                if (value < 0)
                {
                    speed = 0;
                    Status = DeliveryStatus.NotWorking;
                }
                else
                    if (value > 50) speed = 50;
                else 
                    speed = value;
            }
        }

        private int maxDistance;
        public override int MaxDistance
        {
            get => maxDistance;
            protected set
            {
                if (value < 0) maxDistance = 0;
                else
                    if (value > 500) maxDistance = 50;
                else
                    maxDistance = value;
            }
        }

        //Основная коллекция груза
        /// <summary>
        /// Груз.
        /// </summary>
        private List<Product> cargo { get; set; }
        //Внешняя коллекция, которая позволяет только читать данные.
        public IReadOnlyCollection<Product> Cargo { get; private set; } 

        /// <summary>
        /// Грузоподъёмность машины.
        /// </summary>
        public readonly double CarryingCapacity;

        public double CurrentCarryingCapacity 
        {
            get
            {
                double weight = default;
                if (Cargo != null)
                    foreach (var prod in Cargo)
                        weight += prod.Weight;
                return weight;
            }

        }

        public Car(string name, int speed, int maxDistance, double carryingCapacity)
            : base(name, speed, maxDistance)
        {
            id = Interlocked.Increment(ref globalID);
            CarryingCapacity = carryingCapacity;
            cargo = new List<Product>();
            Cargo = cargo.AsReadOnly();
        }

        public override void Delivery(Order order)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            
            cargo.Add(product);
        }
    }
}
