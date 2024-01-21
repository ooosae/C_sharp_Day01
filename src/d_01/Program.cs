using System;
using System.Collections.Generic;

using s21;

class Program
{
    static void method1()
    {var storage = new Storage(40);
        var store = new Store(3, storage);
        
        var customers = new List<Customer>
        {
            new Customer("Anna", 1, 7),
            new Customer("Pavel", 2, 7),
            new Customer("Viktor", 3, 7),
            new Customer("Andrew", 4, 7),
            new Customer("Josh", 5, 7),
            new Customer("Tina", 6, 7),
            new Customer("Katya", 7, 7),
            new Customer("Max", 8, 7),
            new Customer("Bob", 9, 7),
            new Customer("Rose", 10, 7)
        };
        
        store.Open();
        int people1Count = 0;
        int items1Count = 0;
        int people2Count = 0;
        int items2Count = 0;
        int people3Count = 0;
        int items3Count = 0;
        
        for (int i = 0; i < customers.Count; ++i)
        {
            var customer = customers[i];
            customer.FillCart();
            var chosenRegister = customer.ChooseCheckoutWithLeastCustomers(store.GetRegisters);
            if (chosenRegister == store.GetRegisters[0])
            {
                people1Count++;
                items1Count += customer.GetNumberOfGoodsInCart;
            }
            else
            {
                if (chosenRegister == store.GetRegisters[1])
                {
                    people2Count++;
                    items2Count += customer.GetNumberOfGoodsInCart;
                }
                else
                {
                    people3Count++;
                    items3Count += customer.GetNumberOfGoodsInCart;
                }
            }
            chosenRegister.EnqueueCustomer(customer);
        }
        
        while (store.IsOpen && (store.GetRegisters[0].Customers.Count > 0 || store.GetRegisters[1].Customers.Count > 0 || store.GetRegisters[2].Customers.Count > 0))
        {
            for (int i = 0; i < store.GetRegisters.Count; ++i)
            {
                CashRegister register = store.GetRegisters[i];
                if (register.Customers.Count == 0)
                    continue;
                Customer customer = register.DequeueCustomer();
                
                try
                {
                    store.Storage.TakeGoods(customer.GetNumberOfGoodsInCart);
                }
                catch (ArgumentException ex)
                {
                    if (store.Storage.GetNumberOfGoods > 0)
                    {
                        customer.SetNumberOfGoods(customer.GetNumberOfGoodsInCart - store.Storage.GetNumberOfGoods);
                        store.Storage.TakeGoods(store.Storage.GetNumberOfGoods);
                    }
                    
                    Console.WriteLine(customer);
                }

                if (i == 0)
                {
                    people1Count--;
                    if (people1Count == 0)
                        items1Count = 0;
                    else
                        items1Count -= customer.GetNumberOfGoodsInCart; 
                    Console.WriteLine($"{customer} - {register} ({people1Count} people with {items1Count} items behind)");
                }
                else
                {
                    if (i == 1)
                    {
                        people2Count--;
                        if (people2Count == 0)
                            items2Count = 0;
                        else
                            items2Count -= customer.GetNumberOfGoodsInCart; 
                        Console.WriteLine($"{customer} - {register} ({people2Count} people with {items2Count} items behind)");
                    } else
                    {
                        people3Count--;
                        if (people3Count == 0)
                            items3Count = 0;
                        else
                            items3Count -= customer.GetNumberOfGoodsInCart; 
                        Console.WriteLine($"{customer} - {register} ({people3Count} people with {items3Count} items behind)");
                    }
                }
            }
        }

        store.Close();
    }

    static void method2()
    {var storage = new Storage(40);
        var store = new Store(3, storage);
        
        var customers = new List<Customer>
        {
            new Customer("Anna", 1, 7),
            new Customer("Pavel", 2, 7),
            new Customer("Viktor", 3, 7),
            new Customer("Andrew", 4, 7),
            new Customer("Josh", 5, 7),
            new Customer("Tina", 6, 7),
            new Customer("Katya", 7, 7),
            new Customer("Max", 8, 7),
            new Customer("Bob", 9, 7),
            new Customer("Rose", 10, 7)
        };
        
        store.Open();
        int people1Count = 0;
        int items1Count = 0;
        int people2Count = 0;
        int items2Count = 0;
        int people3Count = 0;
        int items3Count = 0;
        
        for (int i = 0; i < customers.Count; ++i)
        {
            var customer = customers[i];
            customer.FillCart();
            var chosenRegister = customer.ChooseCheckoutWithLeastGoods(store.GetRegisters);
            if (chosenRegister == store.GetRegisters[0])
            {
                people1Count++;
                items1Count += customer.GetNumberOfGoodsInCart;
            }
            else
            {
                if (chosenRegister == store.GetRegisters[1])
                {
                    people2Count++;
                    items2Count += customer.GetNumberOfGoodsInCart;
                }
                else
                {
                    people3Count++;
                    items3Count += customer.GetNumberOfGoodsInCart;
                }
            }
            chosenRegister.EnqueueCustomer(customer);
        }
        
        while (store.IsOpen && (store.GetRegisters[0].Customers.Count > 0 || store.GetRegisters[1].Customers.Count > 0 || store.GetRegisters[2].Customers.Count > 0))
        {
            for (int i = 0; i < store.GetRegisters.Count; ++i)
            {
                CashRegister register = store.GetRegisters[i];
                if (register.Customers.Count == 0)
                    continue;
                Customer customer = register.DequeueCustomer();
                
                try
                {
                    store.Storage.TakeGoods(customer.GetNumberOfGoodsInCart);
                }
                catch (ArgumentException ex)
                {
                    if (store.Storage.GetNumberOfGoods > 0)
                    {
                        customer.SetNumberOfGoods(customer.GetNumberOfGoodsInCart - store.Storage.GetNumberOfGoods);
                        store.Storage.TakeGoods(store.Storage.GetNumberOfGoods);
                    }
                    
                    Console.WriteLine(customer);
                }

                if (i == 0)
                {
                    people1Count--;
                    if (people1Count == 0)
                        items1Count = 0;
                    else
                        items1Count -= customer.GetNumberOfGoodsInCart; 
                    Console.WriteLine($"{customer} - {register} ({people1Count} people with {items1Count} items behind)");
                }
                else
                {
                    if (i == 1)
                    {
                        people2Count--;
                        if (people2Count == 0)
                            items2Count = 0;
                        else
                            items2Count -= customer.GetNumberOfGoodsInCart; 
                        Console.WriteLine($"{customer} - {register} ({people2Count} people with {items2Count} items behind)");
                    } else
                    {
                        people3Count--;
                        if (people3Count == 0)
                            items3Count = 0;
                        else
                            items3Count -= customer.GetNumberOfGoodsInCart; 
                        Console.WriteLine($"{customer} - {register} ({people3Count} people with {items3Count} items behind)");
                    }
                }
            }
        }

        store.Close();
    }

    static void Main()
    {
        Console.WriteLine("Method 1: Least Customers:\n");
        method1();
        Console.WriteLine("\n\nMethod 2: Least Items:\n");
        method2();
    }
}