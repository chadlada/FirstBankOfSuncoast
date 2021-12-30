using System;

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
            DisplayGreeting();
        }
    }
}
