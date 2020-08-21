using System;
using System.Collections.Generic;
using System.Collections;

namespace Lab4
{
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            int month;
            string username;

            Console.WriteLine("Enter how many months you will deposit: ");
            month = int.Parse(Console.ReadLine());
            List<Account> accountList = new List<Account>();

            // Loop for creating user account, when username input is blank, the loop will stop
            do
            {
                Console.Write("Enter Customer Name: ");
                username = Console.ReadLine();
                if (username == "")
                {
                    break;
                }

                // ask for initial deposit amount
                Console.Write("Enter " + username + "'s initial deposit amount: ");
                double initialDeposit = double.Parse(Console.ReadLine());
                if (initialDeposit < Account.MinimumInitialBalance)
                {
                    Console.WriteLine("Initial deposit Failed: Your initial deposit should be more than {0}", Account.MinimumInitialBalance);
                    Console.Write("Deposit again? Y/y ");
                    var result = Console.ReadLine();
                    if(result == "Y" | result == "y")
                    {
                        Console.Write("Enter " + username + "'s initial deposit amount: ");
                        initialDeposit = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
                // ask for monthly deposit amount
                Console.Write("Enter " + username + "'s monthly deposit amount: ");
                double monthlyDeposit = double.Parse(Console.ReadLine());
                if (monthlyDeposit < Account.MinimumMonthDeposit)
                {
                    Console.WriteLine("Monthly deposit Failed: Your monthly deposit should be more than {0}", Account.MinimumMonthDeposit);
                    Console.Write("Deposit again? Y/y ");
                    var result = Console.ReadLine();
                    if (result == "Y" | result == "y")
                    {
                        Console.Write("Enter " + username + "'s monthly deposit amount: ");
                        monthlyDeposit = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }

                // create object
                Account account = new Account(username, initialDeposit);
                account.MonthlyDepositAmount = monthlyDeposit;

                for (int m = 0; m < month; m++)
                {
                    account.Withdraw(Account.MonthlyFee);
                    account.Deposit(account.Balance * Account.MonthlyInterstRate);
                    account.Deposit(account.MonthlyDepositAmount);
                    //account.Balance = Math.Round((account.Balance - Account.MonthlyFee) * (1 + Account.MonthlyInterstRate) + monthlyDeposit, 2);
                }

                // store the objects into a list
                accountList.Add(account);

            }
            while (username != "");

            // out put the results from objects in the list
            for (int i = 0; i < accountList.Count; i++)
            {
                Console.WriteLine("After {0} months, {1}'s account ({2}), has a balance of: ${3:F2}", month, accountList[i].OwnerName, accountList[i].AccountNumber, accountList[i].Balance);
            }
            
        }   
    }
}
