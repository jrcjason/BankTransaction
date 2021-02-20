using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public abstract class Decorator: BankAccount
    {
        #region Fields
        protected BankAccount _bankAccount;
        #endregion

        #region Constructor
        public Decorator(BankAccount bankAccount)
        {
            _bankAccount = bankAccount;
        }
        #endregion

        #region Methods
        public override double GetBalance()
        {
            return _bankAccount.GetBalance();
        }
        public override void Withdraw(double amount)
        {
            _bankAccount.Withdraw(amount);
        }
        public override void Deposit(double amount)
        {
            _bankAccount.Deposit(amount);
        }
        #endregion
    }
}
