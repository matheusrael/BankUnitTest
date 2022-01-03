using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public class BankAccountTest
    {
        #region DebitTest
        [TestMethod]
        public void DebitAccount_ReturnCurrentBalance()
        {
            // Arrage
            var account = new Account(1, "Matheus Rael", 10.69m);
            var bankAccount = new BankAccount(account);

            //Act
            var accountResponse = bankAccount.Debit(7.98m);

            //Assert
            Assert.IsTrue(accountResponse.Done);
            Assert.AreEqual(2.71m, accountResponse.Account.Balance);            
        }

        [TestMethod]
        public void DebitAccount_CannotReturnBalanceLessThanZero()
        {
            // Arrage
            var account = new Account(1, "Matheus Rael", 10.69m);
            var bankAccount = new BankAccount(account);

            //Act
            var accountResponse = bankAccount.Debit(20.98m);

            //Assert
            Assert.IsFalse(accountResponse.Done);
            Assert.AreEqual(account.Balance, accountResponse.Account.Balance);
        }

        [TestMethod]

        public void DebitAccount_CannotDebitLessOrEqualZero()
        {
            // Arrage
            var account = new Account(1, "Matheus Rael", 10.69m);
            var bankAccount = new BankAccount(account);

            //Act
            var accountResponse = bankAccount.Debit(0);

            //Assert
            Assert.IsFalse(accountResponse.Done);
            Assert.AreEqual(account.Balance, accountResponse.Account.Balance);
        }
        #endregion

        #region CreditTest

        [TestMethod]
        public void CreditAccount_ReturnTrue()
        {
            // Arrage
            var account = new Account(1, "Matheus Rael", 10.69m);
            var bankAccount = new BankAccount(account);

            //Act
            var currentBalance = bankAccount.Credit(7.98m);

            //Assert
            Assert.AreEqual(18.67m, currentBalance);            
        }

        [TestMethod]
        public void CreditAccount_CreditLessOrEqualZero_ReturnSameBalance()
        {
            // Arrage
            var account = new Account(1, "Matheus Rael", 10.69m);            
            var bankAccount = new BankAccount(account);

            //Act
            var expextedBalance = account.Balance;
            var currentBalance = bankAccount.Credit(-4.9m);

            //Assert
            Assert.AreEqual(expextedBalance, currentBalance);
        }
        #endregion

        #region ChangeOwnerName

        [TestMethod]
        public void ChangeName_DifferentName_ReturnTrue() 
        {
            var account = new Account(1, "Matheus Rael", 10.69m);
            var bankAccount = new BankAccount(account);

            var oldname = account.Name;
            var updatedName = bankAccount.ChangeOwnerAccountName("Matheus Mendes");

            Assert.IsTrue(updatedName);
            Assert.AreNotEqual(oldname, account.Name);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("Matheus Rael")]
        public void ChangeName_SameNameOrEmptyString_ReturnFalse(string newName)
        {
            var account = new Account(1, "Matheus Rael", 10.69m);
            var bankAccount = new BankAccount(account);

            var oldname = account.Name;
            var updatedName = bankAccount.ChangeOwnerAccountName(newName);

            Assert.IsFalse(updatedName);
            Assert.AreEqual(oldname, account.Name);
        }

        #endregion
    }
}