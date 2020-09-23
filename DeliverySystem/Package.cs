using System;
using System.Threading;

namespace DeliverySystem
{
    class Package : Deliveryman
    {
        private static int globalID;
        private int id;
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
                }
                else
                    if (value > 10) speed = 10;
                else
                    speed = value;
            }
        }

        public int maxDistance;
        public override int MaxDistance { get => maxDistance; protected set => maxDistance = 10; }

        public Package(string name)
            :base()
        {
            Name = name;
            maxDistance = 0;
            id = Interlocked.Increment(ref globalID);
        }

        public override void Delivery(DeliveryOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
