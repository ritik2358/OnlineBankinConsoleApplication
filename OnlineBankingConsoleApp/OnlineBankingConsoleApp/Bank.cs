using System;
using System.Collections.Generic;

namespace OnlineBankingConsoleApp
{
    public class Bank
    {
        public List<BankAccount> accounts;
        private List<Transaction> transactions;
        private List<string> records;
        private bool isCheckBookAllotted;

        ValidationMethod validationMethod = new ValidationMethod();
        public Bank()
        {
            accounts = new List<BankAccount>();
            transactions = new List<Transaction>();
            records = new List<string>();
            isCheckBookAllotted = false;
        }

        public void CreateAccount()
        {
            int accountNumber;
            bool isAccountNumberUnique;
            do
            {
                Console.Write("Enter Account Number: ");
                accountNumber = int.Parse(Console.ReadLine());
                isAccountNumberUnique = validationMethod.IsAccountNumberUnique(accountNumber);
                if (!isAccountNumberUnique)
                {
                    Console.WriteLine("Account already exists. Please try with another account number.");
                }
            } while (!isAccountNumberUnique);

            Console.Write("Enter Account Holder Name: ");
            string accountHolderName = Console.ReadLine();

            decimal initialBalance;
            bool isValidInitialBalance;
            do
            {
                Console.Write("Enter Initial Balance: ");
                isValidInitialBalance = decimal.TryParse(Console.ReadLine(), out initialBalance);
                if (!isValidInitialBalance)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!isValidInitialBalance);

            BankAccount account = new BankAccount(accountNumber, accountHolderName, initialBalance);
            accounts.Add(account);
            Console.WriteLine("Account created successfully.");
        }
        public void CheckBalance()
        {
            Console.Write("Enter Account Number: ");
            int checkBalanceAccountNumber = int.Parse(Console.ReadLine());
            BankAccount account = accounts.Find(acc => acc.AccountNumber == checkBalanceAccountNumber);
            if (account != null)
            {
                Console.WriteLine($"Account Holder: {account.AccountHolderName}");
                Console.WriteLine($"Balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void TransferBalance()
        {
            Console.Write("Enter From Account Number: ");
            int fromAccountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter To Account Number: ");
            int toAccountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            BankAccount fromAccount = accounts.Find(acc => acc.AccountNumber == fromAccountNumber);
            BankAccount toAccount = accounts.Find(acc => acc.AccountNumber == toAccountNumber);

            if (fromAccount != null && toAccount != null)
            {
                if (fromAccount.Balance >= amount)
                {
                    fromAccount.Withdraw(amount);
                    toAccount.Deposit(amount);
                    transactions.Add(new Transaction(transactions.Count + 1, fromAccountNumber, toAccountNumber, amount, "Transfer", DateTime.Now));
                    Console.WriteLine("Transfer successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void RecordEntry()
        {
            Console.Write("Enter Account Number: ");
            int staffEntryAccountNumber = int.Parse(Console.ReadLine());
            BankAccount account = accounts.Find(acc => acc.AccountNumber == staffEntryAccountNumber);
            if (account != null)
            {
                Console.WriteLine("Online record entry by staff (data entry)");
                string emailId = "";
                string phoneNo = "";
                string nomineeName = "";
                int choice;
                do
                {
                     Console.WriteLine("1. Add emailID\n2. Add Phone number\n3. Add Nominee Name\n4. Back to Prev Menu");
                     Console.Write("Enter your choice: ");
                     choice = int.Parse(Console.ReadLine());
                
               
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter emailID: ");
                            emailId = Console.ReadLine();
                            records.Add($"EmailId : {emailId}");
                            Console.WriteLine("Email Id added Successfully");
                            break;
                        case 2:
                            Console.WriteLine("Enter Phone number: ");
                            phoneNo = Console.ReadLine();
                            records.Add($"Phone number : {phoneNo}");
                            Console.WriteLine("Phone Number added Successfully");
                            break;
                        case 3:
                            Console.WriteLine("Enter Nominee Name: ");
                            nomineeName = Console.ReadLine();
                            records.Add($"Nominee Name : {nomineeName}");
                            Console.WriteLine("Nominee Name added Successfully");
                            break;
                        case 4:
                            Console.WriteLine("Going Back to Prev Menu..");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }while (choice!=4);
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

        public void SearchRecord()
        {
            Console.Write("Enter Account Number: ");
            int recordSearchAccountNumber = int.Parse(Console.ReadLine());
            BankAccount account = accounts.Find(acc => acc.AccountNumber == recordSearchAccountNumber);
            if (account != null)
            {
                Console.WriteLine($"Records for Account Number: {recordSearchAccountNumber}");
                Console.WriteLine($"Account Holder: {account.AccountHolderName}");
                Console.WriteLine($"Balance: {account.Balance}");

                Console.WriteLine("Records:");
                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

        public void ViewTransactionHistory()
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"Transaction History for Account Number: {accountNumber}");
            foreach (var transaction in transactions)
            {
                if (transaction.FromAccountNumber == accountNumber)
                {
                    Console.WriteLine($"Transaction ID: {transaction.TransactionId}\nTransferred to (Account No): {transaction.ToAccountNumber}\nAmount: {transaction.Amount}\nType: {transaction.Type}\nDate: {transaction.TransactionDate}");
                }
                if (transaction.ToAccountNumber == accountNumber)
                {
                    Console.WriteLine($"Transaction ID: {transaction.TransactionId}\nTransferred from (Account No): {transaction.FromAccountNumber}\nAmount: {transaction.Amount}\nType: {transaction.Type}\nDate: {transaction.TransactionDate}");
                }
            }
        }

        public void AllotCheckBook()
        {
            Console.Write("Enter Account Number: ");
            int checkBookAccountNumber = int.Parse(Console.ReadLine());
            BankAccount account = accounts.Find(acc => acc.AccountNumber == checkBookAccountNumber);
            if (account != null)
            {
                if (!isCheckBookAllotted)
                {
                    Console.WriteLine($"Check book allotted for Account Number: {checkBookAccountNumber}");
                    isCheckBookAllotted = true;
                }
                else
                {
                    Console.WriteLine($"Check book already allotted for Account Number: {checkBookAccountNumber}");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
