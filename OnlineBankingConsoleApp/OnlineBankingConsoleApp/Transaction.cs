using System;
using System.Collections.Generic;
namespace OnlineBankingConsoleApp
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int FromAccountNumber { get; set; }
        public int ToAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<Transaction> transactions;

        public Transaction(int transactionId, int fromAccountNumber, int toAccountNumber, decimal amount, string type, DateTime transactionDate)
        {
            TransactionId = transactionId;
            FromAccountNumber = fromAccountNumber;
            ToAccountNumber = toAccountNumber;
            Amount = amount;
            Type = type;
            TransactionDate = transactionDate;
        }
        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }
    }
}
