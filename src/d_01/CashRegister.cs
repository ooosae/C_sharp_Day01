namespace s21;
using System.Collections.Generic;

public class CashRegister
{
    private readonly string name;
    private readonly Queue<Customer> customers;

    public CashRegister(string name)
    {
        this.name = name;
        this.customers = new Queue<Customer>();
    }

    public string Name => name;

    public Queue<Customer> Customers => customers;

    public void EnqueueCustomer(Customer customer)
    {
        customers.Enqueue(customer);
    }

    public Customer DequeueCustomer()
    {
        if (customers.Count > 0)
        {
            return customers.Dequeue();
        }

        return null;
    }

    public override string ToString()
    {
        return $"Register #{name}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        CashRegister otherCashRegister = (CashRegister)obj;
        return name == otherCashRegister.name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name);
    }
    
    public static bool operator ==(CashRegister register1, CashRegister register2)
    {
        if (ReferenceEquals(register1, null) && ReferenceEquals(register2, null))
        {
            return true;
        }

        if (ReferenceEquals(register1, null) || ReferenceEquals(register2, null))
        {
            return false;
        }

        return register1.name == register2.name;
    }

    public static bool operator !=(CashRegister register1, CashRegister register2)
    {
        return !(register1 == register2);
    }
}