using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem
{
    /// <summary>
    /// Базовый класс для всех доствзиков.
    /// </summary>
    abstract class Deliveryman
    {
        public abstract int ID { get; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        public abstract int Speed { get; protected set; }
        public abstract int MaxDistance { get; protected set; }

        public Deliveryman()
        {
            Name = "";
            Status = DeliveryStatus.NotWorking;
        }

        public Deliveryman(string name)
            : this()
        {
            Name = name;
        }

        public Deliveryman(string name, int speed, int maxDistance)
            : this(name)
        {
            Speed = speed;
            MaxDistance = maxDistance;
        }

        public abstract void Delivery();
    }
}
