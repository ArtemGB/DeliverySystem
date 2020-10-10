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
        private Dictionary<int, Client> clients;
        /// <summary>
        /// Клиенты
        /// </summary>
        public IReadOnlyDictionary<int, Client> Clients { get; private set; }

        public ClientManager()
        {
            clients = new Dictionary<int, Client>();
            Clients = clients;
        }

        /// <summary>
        /// Создаёт и возвращает нового клиента.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="address">Адрес</param>
        /// <param name="phoneCode">Код номера</param>
        /// <param name="phoneNumb">Номер телефона без кода</param>
        /// <returns>Новый клиент.</returns>
        public Client AddClient(string name, string secondName, string address, char phoneCode, string phoneNumb)
        {
            Client newClient = new Client(name, secondName, address, phoneCode, phoneNumb);
            clients.Add(newClient.ID, newClient);
            return newClient;
        }

        /// <summary>
        /// Удаляние клиенты по его ID
        /// </summary>
        /// <param name="ID">ID</param>
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
