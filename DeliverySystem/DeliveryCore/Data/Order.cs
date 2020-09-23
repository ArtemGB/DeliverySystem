﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace DeliverySystem.DeliveryCore.Data
{
    class Order
    {
        private static int globalID;
        public readonly int ID;
        public Client Client { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public double Weight
        {
            get
            {
                double weight = default;
                if(Products != null)
                    foreach (var prod in Products)
                        weight += prod.Weight;
                return weight;
            }
        }

        public List<Product> Products { get; private set; }

        private double distance;
        public double Distance
        {
            get => distance;
            set
            {
                if (value <= 0) throw new ArgumentException("Длина не может быть меньше нуля.");
                distance = value;
            }
        }

        public Order(Client client)
        {
            ID = Interlocked.Increment(ref globalID);
            Products = new List<Product>();
            Client = client;
        }

        public Order(Client client, string address2)
            : this(client)
        {
            Address1 = client.Address;
            Address2 = address2;
        }

        public Order(Client client, string address1, string address2)
            :this(client)
        {
            Address1 = address1;
            Address2 = address2;
        }
    }
}