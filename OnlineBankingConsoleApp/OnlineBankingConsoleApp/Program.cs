using System;

namespace OnlineBankingConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank= new Bank();
            int choice;
            do
            {
                Console.WriteLine("*****Welcome to Online Banking System*****\n1. Create Bank Account\n2. Check Balance\n3. Transfer Balance\n4. View Transaction History\n5. Online record entry by staff (data entry)\n6. Online record search\n7. Check book allotment\n8. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        bank.CreateAccount();
                        break;
                    case 2:
                        bank.CheckBalance();
                        break;
                    case 3:
                        bank.TransferBalance();
                        break;
                    case 4:
                        bank.ViewTransactionHistory();
                        break;
                    case 5:
                        bank.RecordEntry();
                        break;
                    case 6:
                        bank.SearchRecord();
                        break;
                    case 7:
                        bank.AllotCheckBook();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 8);
        }
    }
}
