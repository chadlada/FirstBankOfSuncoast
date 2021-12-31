using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public DateTime Date { get; set; }
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
                //Console.WriteLine("This is not a valid entry. Action cancelled.");
                return 0;
            }
        }



        static void Main(string[] args)
        {
            var transactions = new List<Transaction>();
            // var date = new DateTime; TBD
            DisplayGreeting();
            var userChoice = Console.ReadLine();
            var keepGoing = true;
            var transaction = new Transaction();

            while (keepGoing)
            {
                if (userChoice == "7")
                {
                    keepGoing = false;
                    Console.WriteLine("Thank you for using Suncoast! \n\n");
                    break;
                }

                else if (userChoice == "1")
                {
                    transaction.Date = DateTime.Now;
                    transaction.Type = "Deposit";
                    transaction.Account = "Checking";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Current Balance: TBD\n");

                    Console.WriteLine("\n\nThank you for banking with us!");

                }

                else if (userChoice == "2")
                {
                    transaction.Date = DateTime.Now;
                    transaction.Type = "Deposit";
                    transaction.Account = "Checking";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Current Balance: TBD\n");

                    Console.WriteLine("\n\nThank you for banking with us!");
                }

                else if (userChoice == "3")
                {

                }

                else if (userChoice == "4")
                {
                    transaction.Date = DateTime.Now;
                    transaction.Type = "Deposit";
                    transaction.Account = "Savings";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Current Balance: TBD\n");

                    Console.WriteLine("\n\nThank you for banking with us!");
                }

                else if (userChoice == "5")
                {
                    transaction.Date = DateTime.Now;
                    transaction.Type = "Withdraw";
                    transaction.Account = "Savings";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    Console.WriteLine("\n\n####### -RECEIPT- #######\n\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Current Balance: TBD\n");

                    Console.WriteLine("\n\nThank you for banking with us!");
                }

                else if (userChoice == "6")
                {

                }

            }

        }
    }
}
