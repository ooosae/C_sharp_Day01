namespace s21
{
    using System;
    using System.Collections.Generic;

    public class Store
    {
        private readonly List<CashRegister> cashRegisters;
        private readonly Storage storage;
        private bool openStatus;

        public Store(int numberOfCashRegisters, Storage storage)
        {
            openStatus = false;
            if (numberOfCashRegisters <= 0)
            {
                throw new ArgumentException("The number of cash registers must be greater than zero.");
            }

            this.cashRegisters = new List<CashRegister>();
            this.storage = storage;

            for (int i = 1; i <= numberOfCashRegisters; i++)
            {
                cashRegisters.Add(new CashRegister(i.ToString()));
            }
        }

        public List<CashRegister> CashRegisters => cashRegisters;

        public Storage Storage => storage;

        public void Open()
        {
            openStatus = true;
            Console.WriteLine("The store is now open!");
        }

        public void Close()
        {
            openStatus = false;
            Console.WriteLine("The store is now closed.");
        }

        public bool IsOpen => openStatus;
        public List<CashRegister> GetRegisters => cashRegisters;

    }
}