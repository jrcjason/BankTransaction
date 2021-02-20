using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LoggingDecorator: Decorator, ILogger
    {
        #region Fields
        private string _logs;
        #endregion

        #region Constructor
        public LoggingDecorator(BankAccount bankAccount) : base(bankAccount)
        {
            
        }
        #endregion

        #region Public Methods
        public override double GetBalance()
        {
            var amount = _bankAccount.GetBalance();
            var textToLog = $"Your Balance: {amount}";
            _logs = string.IsNullOrEmpty(_logs) ? textToLog : _logs + $"\n{textToLog}";
            Console.WriteLine(textToLog);
            return amount;
        }

        public override void Withdraw(double amount)
        {
            var textToLog = $"Withdrawed {amount}.";
            _logs = string.IsNullOrEmpty(_logs) ? textToLog : _logs + $"\n{textToLog}";
            Console.WriteLine(textToLog);
        }

        public override void Deposit(double amount)
        {
            var textToLog = $"Deposited {amount}.";
            _logs = string.IsNullOrEmpty(_logs) ? textToLog : _logs + $"\n{textToLog}";
            Console.WriteLine(textToLog);
        }

        public void Log(string textToLog)
        {
            _logs = string.IsNullOrEmpty(_logs) ? textToLog : _logs + $"\n{textToLog}";
            Console.WriteLine(textToLog);
        }

        public string GetAllLogs()
        {
            return _logs;
        }
        #endregion

    }
}
