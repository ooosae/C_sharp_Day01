namespace s21;

using System.Collections.Generic;
using System.Linq;

public static class CustomerExtensions
{
    public static CashRegister ChooseCheckoutWithLeastCustomers(this Customer customer, IEnumerable<CashRegister> cashRegisters)
    {
        return cashRegisters
            .OrderBy(register => register.Customers.Count)
            .FirstOrDefault();
    }

    public static CashRegister ChooseCheckoutWithLeastGoods(this Customer customer, IEnumerable<CashRegister> cashRegisters)
    {
        return cashRegisters
            .OrderBy(register => register.Customers.Sum(c => c.GetNumberOfGoodsInCart))
            .FirstOrDefault();
    }
}