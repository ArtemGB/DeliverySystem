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
        public int ID { get; private set; }
        private static int globalID;
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }
        public int Speed { get; private set; }
        public int MaxDistance { get; private set; }

        public Deliveryman(string name)
        {
            Name = name;
            Status = DeliveryStatus.NotWorking;
        }

        public virtual void Delivery() { }
    }
}
