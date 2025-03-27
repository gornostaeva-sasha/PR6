using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankAccountTestss
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

           
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                
                StringAssert.Contains(ex.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("Ожидаемое исключение не было выброшено.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
           
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
              
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("Ожидаемое исключение не было выброшено.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsNegative_ShouldThrowArgumentOutOfRange()
        {
            
            double beginningBalance = 100.0;
            double creditAmount = -50.0;
            BankAccount account = new BankAccount("Mr. Credit Tester", beginningBalance);

           
            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
             
                StringAssert.Contains(e.Message, BankAccount.CreditAmountIsNegativeMessage);
                return;
            }

            Assert.Fail("Ожидаемое исключение не было выброшено.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsValid_ShouldIncreaseBalance()
        {
            
            double beginningBalance = 100.0;
            double creditAmount = 50.0;
            BankAccount account = new BankAccount("Mr. Credit Tester", beginningBalance);

           
            account.Credit(creditAmount);

           
            Assert.AreEqual(150.0, account.Balance);
        }
    }
}
