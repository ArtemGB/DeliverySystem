﻿using System;
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
                if (value < 0)
                {
                    speed = 0;
                    Status = DeliveryStatus.NotWorking;
                }
                else
                    if (value > 10) speed = 10;
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
                    if (value > 50) maxDistance = 50;
                else 
                    maxDistance = value;
            }
        }

        public Courier(string name, int speed, int maxDistance)
            : base(name, speed, maxDistance)
        {
            id = Interlocked.Increment(ref globalCourierID);
            Speed = speed;
        }

        public override void Delivery(DeliveryOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
