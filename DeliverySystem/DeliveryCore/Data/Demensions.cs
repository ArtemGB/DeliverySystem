using System;

namespace DeliverySystem.DeliveryCore.Data
{
    class Demensions
    {
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

        public Demensions()
        {
            Length = 0;
            Width = 0;
            Height = 0;
        }

        public Demensions(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}
