using System;
using System.Threading;

namespace DeliverySystem
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

        private double length;
        public double Length
        {
            get => length;
            set
            {
                if (value < 0) throw new ArgumentException("Значение длинны не может быть меньше нуля.");
                length = value;
            }
        }

        private double width;
        public double Width
        {
            get => width;
            set
            {
                if (value < 0) throw new ArgumentException("Значение ширины не может быть меньше нуля.");
                width = value;
            }
        }

        private double height;
        public double Height
        {
            get => height;
            set
            {
                if (value < 0) throw new ArgumentException("Значение высоты не может быть меньше нуля.");
                height = value;
            }
        }

        /// <summary>
        /// Хрупкий товар.
        /// </summary>
        public bool Brittle { get; set; }

        public Product(string name)
        {
            Name = name;
            Length = 0;
            Width = 0;
            Height = 0;
            Brittle = false;
            ID = Interlocked.Increment(ref globalID);
        }

        public Product(string name, int Length, int Width, int Hieght)
            : this(name)
        {
            this.Length = Length;
            this.Width = Width;
            this.Height = Hieght;
        }

        public Product(string name, int Length, int Width, int Hieght, bool Brittle)
        :this(name, Length, Width, Hieght)
        {
            this.Brittle = Brittle;
        }
    }
}
