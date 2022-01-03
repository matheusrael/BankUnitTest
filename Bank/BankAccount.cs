using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        private Account Account { get; set; }

        public BankAccount(Account account)
        {
            Account = account;
        }

        public BankAccountResponse Debit(decimal valueDebit) 
        {
            if (ValidValueToDebit(Account.Balance, valueDebit))
            {
                Account.Balance -= valueDebit;

                return new BankAccountResponse(Account, true);
            }
            else
            {
                return new BankAccountResponse(Account, false);
            }

            
        }

        public decimal Credit(decimal valueCredit)
        {
            if (ValidValueToCredit(valueCredit))
            {
                Account.Balance += valueCredit;

                return Account.Balance;                
            }

            return Account.Balance;
        }        

        public bool ChangeOwnerAccountName(string newName) 
        {
            var oldName = Account.Name;            

            if (IsValidNewName(newName, oldName))
            {
                Account.Name = newName;

                return true;
            }
            else
            {
                return false;
            }
        }


        private bool ValidValueToDebit(decimal currentBalance, decimal valueToDebit)
        {
            if (valueToDebit > 0 && valueToDebit <= currentBalance)            
                return true;            
            else
                return false;
        }

        private bool ValidValueToCredit(decimal valueCredit)
        {
            if(valueCredit <= 0)
                return false;
            else
                return true;
        }
        private bool IsValidNewName(string newName, string oldName)
        {
            if (newName == oldName || string.IsNullOrWhiteSpace(newName))
                return false;
            else
                return true;
        }
    }
}
