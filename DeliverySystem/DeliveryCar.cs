﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace DeliverySystem
{
    class DeliveryCar : Deliveryman
    {
        private static int GlobalCarID;
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
        private List<Product> CargoCore { get; set; }
        /// <summary>
        /// Груз.
        /// </summary>
        public IReadOnlyCollection<Product> Cargo { get; private set; } //Внешняя коллекция, которая позволяет только читать данные.
        /// <summary>
        /// Грузоподъёмность машины.
        /// </summary>
        public readonly double CarryingCapacity;

        public DeliveryCar(string name, int speed, int maxDistance, double carryingCapacity)
            : base(name, speed, maxDistance)
        {
            id = Interlocked.Increment(ref GlobalCarID);
            CarryingCapacity = carryingCapacity;
            CargoCore = new List<Product>();
            Cargo = CargoCore.AsReadOnly();

        }

        public override void Delivery(DeliveryOrder order)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            CargoCore.Add(product);
        }
    }
}
