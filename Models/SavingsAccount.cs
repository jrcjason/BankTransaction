using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class SavingsAccount: BankAccount
    {
        #region Fields
        private static readonly double _initialBalance = 5000.00;
        private List<Transaction> _transactions = new List<Transaction>();
        #endregion

        #region Constructor
        public SavingsAccount()
        {
            Deposit(_initialBalance);
        }
        #endregion

        #region Public Methods
        public override void Withdraw(double amount)
        {
            _transactions.Add(new Transaction(-amount));
        }

        public override void Deposit(double amount)
        {
            _transactions.Add(new Transaction(amount));
        }

        public override double GetBalance()
        {
            return _transactions.Sum(x => x.Amount);
        }
        #endregion
    }
}