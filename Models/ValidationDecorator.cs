using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ValidationDecorator : Decorator
    {
        #region Constructor
        public ValidationDecorator(BankAccount bankAccount) : base(bankAccount)
        {

        }
        #endregion

        #region Public Methods
        public override void Withdraw(double amount)
        {
            if (amount < 300)
            {
                throw new Exception("Minimum withdrawal is 300.");
            }

            if (amount > 10000)
            {
                throw new Exception("Maximum withdrawal amount is 10000.");
            }

            if (GetBalance() - amount < 0)
            {
                throw new Exception("Withdrawal amount should not be more than the current balance.");
            }
        }

        public override void Deposit(double amount)
        {
            if (amount < 1000)
            {
                throw new Exception("Minimum deposit is 1000.");
            }

            if (amount > 50000)
            {
                throw new Exception("Maximum deposit is 50000.");
            }
        }
        #endregion
    }
}
