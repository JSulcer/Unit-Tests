using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 5.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 13.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = 13.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Credit_AccountHasBeenFrozen_ShouldThrowArgument()
        {
            double beginningBalance = 10.00;
            double creditAmount = 5.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();

            try
            {
                account.Credit(creditAmount);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Account frozen");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, "amount");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 3.00;
            double expected = 14.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Credit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenBalanceisNegative_AccountIsFrozen()
        {
            // arrange  
            double beginningBalance = 7.00;
            double debitAmount = 5.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Account frozen");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}