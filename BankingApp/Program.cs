using System;
using System.Formats.Tar;

namespace BankingApp
{
    class BankAccount
    {
        private string _username;
        private string _password;
        private double _accountBalance = 0;
        public BankAccount(string initialUsername, string initialPassword)
        {
            _username = initialUsername;
            _password = initialPassword;
        }
        public bool Authenticate(string password) 
        {
            return (password == _password);
        }
        public double GetAccountBalance()
        {
            return _accountBalance;
        }
        public double ModifyAccountBalance(double modifyBy)
        {
            _accountBalance += modifyBy;
            return _accountBalance;
        }
    }
    internal class Program
    {
        private static Dictionary<string, BankAccount> _accounts = new Dictionary<string, BankAccount>();
        private static bool _programActive = true;
        private static void ThrowError(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Error]: " + message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue ..");
            Console.ReadLine();
        }
        private static void SignUp()
        {
            // Header
            Console.WriteLine("Sign up");

            //Main body
            Console.Write("Username: ");
            string? username = Console.ReadLine();

            if (_accounts.ContainsKey(username) == true)
            {
                ThrowError("This username is already in use.");
                return;
            }

            Console.Write("Password: ");
            string? password = Console.ReadLine();

            if (username != null && password != null)
            {
                BankAccount newAccount = new BankAccount(username, password);
                _accounts.Add(username, newAccount);
            }
        }
        private static void LogIn()
        {
            //Header
            Console.WriteLine("Log in");

            //Main body
            Console.Write("Username: ");
            string? username = Console.ReadLine();
            Console.Write("Password: ");
            string? password = Console.ReadLine();

            BankAccount myAccount;
            if (_accounts.TryGetValue(username, out myAccount) == true) 
            {
                if (myAccount.Authenticate(password) == true)
                {
                    Console.Clear();
                    Console.WriteLine("Logged in!");
                    Console.WriteLine("Balance: " + myAccount.GetAccountBalance());
                    Console.Read();
                    return;
                }
            }
            ThrowError("Invalid username or password.");
        }
        static void Main(string[] args)
        {
            while (_programActive == true)
            {
                Console.Clear();
                Console.WriteLine("Select program mode.");
                Console.WriteLine("[1]: Sign up");
                Console.WriteLine("[2]: Log in");
                Console.WriteLine("[3]: Exit");

                ConsoleKeyInfo userSelection = Console.ReadKey();
                Console.Clear();

                if (userSelection.Key == ConsoleKey.D1)
                {
                    SignUp();
                }
                else if (userSelection.Key == ConsoleKey.D2)
                {
                    LogIn();
                } 
                else if (userSelection.Key == ConsoleKey.D3)
                {
                    _programActive = false;
                }
            }
        }
    }
}