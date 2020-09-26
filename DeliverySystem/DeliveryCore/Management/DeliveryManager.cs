using System;
using System.Collections.Generic;
using DeliverySystem.DeliveryCore.Data;

namespace DeliverySystem.DeliveryCore.Management
{
    class DeliveryManager
    {
        private Dictionary<int, Courier> couriers;
        public IReadOnlyDictionary<int, Courier> Couriers;

        private Dictionary<int, Car> cars;
        public IReadOnlyDictionary<int, Car> Cars;

        private Dictionary<int, Package> packages;
        public Dictionary<int, Package> Packages;

        public DeliveryManager()
        {
            couriers = new Dictionary<int, Courier>();
            Couriers = couriers;
            cars = new Dictionary<int, Car>();
            Cars = cars;
            packages = new Dictionary<int, Package>();
            Packages = packages;
            Car car = new Car("edwe", 15, 15, 15);
            
        }

        public Courier AddCourier(string name, int speed, int maxDistance)
        {
            Courier courier = new Courier(name, speed, maxDistance);
            couriers.Add(courier.ID, courier);
            return courier;
        }

        public void RemoveCourier(int ID)
        {
            try
            {
                couriers.Remove(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
