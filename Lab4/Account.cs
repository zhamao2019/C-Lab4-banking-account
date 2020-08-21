using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Account
    {
        public int AccountNumber { get; }
        public string OwnerName { get; set; }
        public double MonthlyDepositAmount;
        public double Balance { get; private set; }

        public static double MonthlyFee = 4;
        public static double MonthlyInterstRate = 0.0025;
        public static double MinimumInitialBalance = 1000;
        public static double MinimumMonthDeposit = 50;

  
        public Account(string name, double initialBalance)
        {
            
            this.OwnerName = name;
            this.Balance = initialBalance;

            // ceate a randow AccountNumber in format 9****
            Random random = new Random();
            int randomNumber = random.Next(90000, 99999);
            this.AccountNumber = randomNumber;
           
        }

        //public static void setInterestRate(double interestRate)
        //{
        //    MonthlyInterstRate = interestRate;
        //}

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("your balance is less than your withdraw");
            }
        }
        
    }
}
