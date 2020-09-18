using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliverySystem
{
    class Courier : Deliveryman
    {

        private static int globalCourierID;
        private readonly int id;
        public override int ID
        {
            get => id;
        }

        private int speed;
        public override int Speed
        {
            get => speed;
            protected set
            {
                if (value < 0) speed = 0;
                if (value > 50) speed = 50;
            }
        }

        public int maxDistance;
        public override int MaxDistance
        {
            get => maxDistance;
            protected set
            {
                if (value < 0) maxDistance = 0;
            }
        }

        public Courier(string name, int speed, int maxDistance)
            : base(name, speed, maxDistance)
        {
            id = Interlocked.Increment(ref globalCourierID);
        }

        public override void Delivery()
        {
            throw new NotImplementedException();
        }
    }
}
