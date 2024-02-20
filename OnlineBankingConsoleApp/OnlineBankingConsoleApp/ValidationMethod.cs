using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingConsoleApp
{
    internal class ValidationMethod 
    {
        public bool IsAccountNumberUnique(int accountNumber)
        {
            Bank bank = new Bank();
            foreach (var account in bank.accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
