using System;
using System.Threading;

namespace DeliverySystem.DeliveryCore.Data
{
    class Product
    {
        private static int globalID;
        public readonly int ID;

        public string Name;
        private double weight;
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0) throw new ArgumentException("Значение веса не может быть меньше нуля.");
            }
        }

        public readonly Demensions Demensions;

        /// <summary>
        /// Хрупкий товар.
        /// </summary>
        public bool Brittle { get; set; }

        private Product()
        {
            ID = Interlocked.Increment(ref globalID);
            Brittle = false;
        }

        public Product(string name, int Length, int Width, int Hieght)
            : this()
        {
            
            Name = name;
            Demensions = new Demensions(Length, Width, Hieght);
        }

        public Product(string name, Demensions demensions)
            :this()
        {
            Demensions = demensions;
        }

        public Product(string name, int Length, int Width, int Hieght, bool Brittle)
        :this(name, Length, Width, Hieght)
        {
            this.Brittle = Brittle;
        }
    }
}
