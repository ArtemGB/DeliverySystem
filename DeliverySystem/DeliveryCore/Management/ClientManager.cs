using System;
using System.Collections.Generic;
using DeliverySystem.DeliveryCore.Data;

namespace DeliverySystem.DeliveryCore.Management
{
    class ClientManager
    {
        // Делаем два словаря, один из которых является обычным словарём
        // Второй позволяет только просмотреть содержимое.
        // Это необходимо т.к. ключом является ID клиента
        // И нельзя допускать, чтобы можно было добавить клиента не с его ID
        // Т.е. сделать так. чтобы в ключ записывался тот ID, что и у клиента, а не случайное число.
        private Dictionary<int, Client> clients { get; set; }
        public IReadOnlyDictionary<int, Client> Clients { get; private set; }

        public ClientManager()
        {
            clients = new Dictionary<int, Client>();
            Clients = clients;
        }


        public void AddClient(Client client)
        {
            if (client != null)
            {
                try
                {
                    // Добавляем клиента с его же ID.
                    clients.Add(client.ID, client);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Такой клиент уже существует.");
                }
            }
        }

        public void RemoveClient(Client client)
        {
            if (client != null)
            {
                if (clients.ContainsKey(client.ID))
                    clients.Remove(client.ID);
                else 
                    throw new ArgumentException("Такого клиента не существует.");
            }
            else throw new ArgumentException("Параметр client равен null.");
        }

        public void RemoveClient(int ID)
        {
            if (clients.ContainsKey(ID))
            {
                clients.Remove(ID);
            }
            else throw new ArgumentException("Такого клиента не существует.");
        }
    }
}
