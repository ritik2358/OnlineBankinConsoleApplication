using System;

namespace OnlineBankingConsoleApp
{
      public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
    public class BankAccount : IBankAccount
    {
        public int AccountNumber { get; private set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(int accountNumber, string accountHolderName, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
    }
}
