using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Transaction
    {
        #region Properties
        public double Amount { get; }
        #endregion

        #region Constructor
        public Transaction(double amount)
        {
            this.Amount = amount;
        }
        #endregion
    }
}
