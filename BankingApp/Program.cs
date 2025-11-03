using System;

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
        private static void ThrowError(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Error]: " + message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue ..");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            
        }
    }
}