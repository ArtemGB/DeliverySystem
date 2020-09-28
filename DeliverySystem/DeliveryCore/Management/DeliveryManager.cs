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
        public IReadOnlyDictionary<int, Package> Packages;

        public DeliveryManager()
        {
            couriers = new Dictionary<int, Courier>();
            Couriers = couriers;
            cars = new Dictionary<int, Car>();
            Cars = cars;
            packages = new Dictionary<int, Package>();
            Packages = packages;
            
        }

        /// <summary>
        /// Создаёт нового курьера и добавляет его в коллекцию курьеров.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speed"></param>
        /// <param name="maxDistance"></param>
        /// <returns>Новый курьер.</returns>
        public Courier AddCourier(string name, int speed, int maxDistance)
        {
            Courier courier = new Courier(name, speed, maxDistance);
            couriers.Add(courier.ID, courier);
            return courier;
        }

        /// <summary>
        /// Удаляет курьера по ID, в случае отсутствия курьера с указанным ID, генерирует исключение.
        /// </summary>
        /// <param name="ID"></param>
        public void RemoveCourier(int ID)
        {
            if (couriers.ContainsKey(ID))
            {
                couriers.Remove(ID);
            }
            else throw new ArgumentException("Такого курьера не существует.");
        }

        public Car AddCar(string name, int speed, int maxDistance, double carryingCapacity)
        {
            Car car = new Car(name, speed, maxDistance, carryingCapacity);
            cars.Add(car.ID, car);
            return car;
        }

        public void RemoveCar(int ID)
        {
            if (cars.ContainsKey(ID))
            {
                cars.Remove(ID);
            }
            else throw new ArgumentException("Такой машины не существует.");
        }

        public Package AddPackage(string name)
        {
            Package package = new Package(name);
            packages.Add(package.ID, package);
            return package;
        }

        public void RemovePackage(int ID)
        {
            if (packages.ContainsKey(ID))
            {
                packages.Remove(ID);
            }
            else throw new ArgumentException("Такой машиныпочтовой службы не существует.");
        }
    }
}
