using System;
using System.Threading;

namespace DeliverySystem.DeliveyCore.Data
{
    class Client
    {
        private static int globalClientID;
        public readonly int ID;
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }

        private char phoneNumberCode;
        public char PhoneNumberCode
        {
            get => phoneNumberCode;
            set
            {
                if (char.IsDigit(value))
                    phoneNumberCode = value;
                else throw new ArgumentException("Некорректный код.");
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                //Длина номера телефона без кода 10 символов
                if (value.Length == 10)
                {
                    //Проверяем корректность введённого номера
                    //Он должен состоять только из цифр.
                    if (long.TryParse(value, out _))
                        phoneNumber = value;
                    else throw new ArgumentException("Некорректный номер.");
                }
                else throw new ArgumentException("Некорректная длинна номера.");
                
            }
        }

        public Client(string name, string secondName, string address, char phoneCode, string phoneNumb)
        {
            ID = Interlocked.Increment(ref globalClientID);
            Name = name;
            SecondName = secondName;
            Address = address;
            PhoneNumberCode = phoneCode;
            PhoneNumber = phoneNumb;
        }

    }
}
