using Autofac;
using Contracts;
using Models;
using System;

namespace BankTransaction
{
    class Program
    {
        #region Fields
        private static BankAccount _bankAccount;
        private static LoggingDecorator _logger;
        private static ValidationDecorator _validator;
        #endregion

        #region MainProgram
        static void Main(string[] args)
        {
            var container = ConfigureContainer();
            _bankAccount = container.Resolve<BankAccount>();
            _logger = container.Resolve<LoggingDecorator>();
            _validator = container.Resolve<ValidationDecorator>();

            Console.WriteLine("Enter action followed by amount e.g. \"withdraw 2000\". Enter \"logs\" to get all logs. Enter \"exit\" to exit the program.");
            var input = Console.ReadLine();
            while (input != "exit")
            {
                try
                {
                    if (input.Contains("withdraw "))
                    {
                        ProcessWithdraw(input);
                    }
                    else if (input.Contains("deposit "))
                    {
                        ProcessDeposit(input);
                    }
                    else if (input.Contains("balance"))
                    {
                        GetBalance();
                    }
                    else if (input == "logs")
                    {
                        Console.WriteLine("Here are all the logs:");
                        Console.WriteLine(_logger.GetAllLogs());
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(ex.Message);
                }
                finally
                {
                    input = Console.ReadLine();
                }
            }
        }
        #endregion

        #region PrivateMethods
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SavingsAccount>().As<BankAccount>().SingleInstance();
            builder.RegisterType<LoggingDecorator>();
            builder.RegisterType<ValidationDecorator>();
            return builder.Build();
        }

        private static void ProcessDeposit(string input)
        {
            var splitted = input.Split(' ');
            if (!string.IsNullOrEmpty(splitted[1]))
            {
                double amount;
                double.TryParse(splitted[1], out amount);
                _validator.Deposit(amount);
                _bankAccount.Deposit(amount);
                _logger.Deposit(amount);
            }
        }

        private static void ProcessWithdraw(string input)
        {
            var splitted = input.Split(' ');
            if (!string.IsNullOrEmpty(splitted[1]))
            {
                double amount;
                double.TryParse(splitted[1], out amount);
                _validator.Withdraw(amount);
                _bankAccount.Withdraw(amount);
                _logger.Withdraw(amount);
            }
        }

        private static void GetBalance()
        {
            _logger.GetBalance();
        }
        #endregion
    }
}