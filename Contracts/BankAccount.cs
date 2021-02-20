using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public abstract class BankAccount
    {
        public abstract double GetBalance();
        public abstract void Withdraw(double amount);
        public abstract void Deposit(double amount);
    }
}
