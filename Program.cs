using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public string Type { get; set; }
        public string Account { get; set; }
        public int Amount { get; set; }
    }

    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to First Bank of Suncoast     ");
            Console.WriteLine("----------------------------------------\n");

            Console.WriteLine("-*-*-*-*-*-*-*-*-MENU-*-*-*-*-*-*-*-*-\n\n\n");


            Console.WriteLine("Checking Account:\n");
            Console.WriteLine("(1)Checking Deposit");
            Console.WriteLine("(2)Checking Withdraw");
            Console.WriteLine("(3)Checking Balance Statement\n");

            Console.WriteLine("Savings Account:\n");
            Console.WriteLine("(4)Savings Deposit");
            Console.WriteLine("(5)Savings Withdraw");
            Console.WriteLine("(6)Savings Balance Statement");
            Console.WriteLine("(7)Quit\n");

            Console.WriteLine("Please choose a letter from the options above, then press ENTER.\n");
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;

        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }



        static void Main(string[] args)
        {
            var transactions = new List<Transaction>();
            var transaction = new Transaction();
            var keepGoing = true;

            if (File.Exists("transactions.csv"))

            {
                var fileReader = new StreamReader("transactions.csv");

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)

                {
                    HasHeaderRecord = true,
                };

                var csvReader = new CsvReader(fileReader, config);

                transactions = csvReader.GetRecords<Transaction>().ToList();
                Console.WriteLine(transactions);

            }



            while (keepGoing)
            {
                DisplayGreeting();
                var userChoice = Console.ReadLine();

                if (userChoice == "7")
                {
                    keepGoing = false;
                    Console.WriteLine("Thank you for using Suncoast! \n\n");
                    break;
                }

                else if (userChoice == "1")
                {
                    transaction.Type = "Deposit";
                    transaction.Account = "Checking";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);
                    int receiptCheckingBalance = ComputeCheckingBalance(transactions);


                    Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                    Console.WriteLine("Transaction Approved\n");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    // Console.WriteLine($"Balance: ${checkingBalance}");

                    Console.WriteLine("\n\nThank you for banking with us!");
                }

                else if (userChoice == "2")
                {
                    transaction.Type = "Withdraw";
                    transaction.Account = "Checking";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    //- Check balance report for available funds
                    //- Tally all transaction amounts through the new variable amount from savings account running balance (var checkingBalance).
                    //- Deduct transaction amount from balance
                    var checkingBalance = ComputeCheckingBalance(transactions);

                    var withdrawApproval = transaction.Amount - checkingBalance;

                    if (withdrawApproval > 0)

                    {
                        //If negative balance is >0 = insufficient funds:

                        //- Print Receipt
                        //- cancel transaction
                        Console.WriteLine($"Transaction cancelled due to insufficient funds.\n");
                        Console.WriteLine("\n######## -RECEIPT- ########\n");
                        Console.WriteLine("**Transaction Declined**");
                        Console.WriteLine("Reason: Insufficient Funds\n");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Amount: ${transaction.Amount}");
                        Console.WriteLine($"Balance: ${checkingBalance}\n");
                        Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                    }

                    //If positive balance is <=0 = approved:
                    else
                    {

                        Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                        Console.WriteLine("Transaction Approved");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Amount: {transaction.Amount}");
                        Console.WriteLine($"Current Balance: TBD\n");

                        Console.WriteLine("\n\nThank you for banking with us!");
                    }
                }

                else if (userChoice == "3")
                {
                    {
                        var statementChecking = transactions.Where(transaction => transaction.Account == "Checking");

                        foreach (var checkingTransaction in statementChecking)
                        {
                            //- Console.WriteLine the line listing each transaction
                            //- loop generating the following linelisted:
                            //- Account, Transaction, Amount
                            Console.WriteLine($"\n{checkingTransaction.Account}, {checkingTransaction.Type}, ${checkingTransaction.Amount}");
                        }

                        var checkingBalance = ComputeCheckingBalance(transactions);

                        //- Tally transactions to determine balance.
                        //- Console.WriteLine the Balance: $
                        Console.WriteLine($"\nYour checking account balance is ${checkingBalance}\n\n");
                        Console.WriteLine("Thank you for banking with First Bank of Suncoast");
                        // - Return to menu

                    }
                }
                else if (userChoice == "4")
                {
                    transaction.Type = "Deposit";
                    transaction.Account = "Savings";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    int savingsBalance = ComputeSavingsBalance(transactions);

                    Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Current Balance: TBD\n");

                    Console.WriteLine("\n\nThank you for banking with us!");
                }

                else if (userChoice == "5")
                {
                    transaction.Type = "Withdraw";
                    transaction.Account = "Savings";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    int savingsBalance = ComputeSavingsBalance(transactions);

                    var withdrawApproval = transaction.Amount - savingsBalance;

                    if (withdrawApproval > 0)
                    {
                        Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Amount: {transaction.Amount}");
                        Console.WriteLine($"Current Balance: TBD\n");

                        Console.WriteLine("\n\nThank you for banking with us!");
                    }

                    else if (userChoice == "6")
                    {

                    }

                    var fileWriter = new StreamWriter("transactions.csv");
                    var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                    csvWriter.WriteRecords(transactions);
                    fileWriter.Close();
                }
            }
            static int ComputeSavingsBalance(List<Transaction> transactions)
            {
                //Savings Balance
                var totalSavingsDeposits = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);
                var totalSavingsWithdraw = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);
                var savingsBalance = totalSavingsDeposits - totalSavingsWithdraw;
                return savingsBalance;
            }
            static int ComputeCheckingBalance(List<Transaction> transactions)
            {
                var receiptCheckingDeposits = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);
                var receiptCheckingWithdraw = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);
                var receiptCheckingBalance = receiptCheckingDeposits - receiptCheckingWithdraw;

                return receiptCheckingBalance;
            }


        }
    }

}