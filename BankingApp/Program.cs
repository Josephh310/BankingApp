using System;

namespace BankingApp
{
    class BankAccount
    {
        private string Username;
        private string Password;
        private double AccountBalance = 0;
        public BankAccount(string InitialUsername, string InitialPassword)
        {
            Username = InitialUsername;
            Password = InitialPassword;
        }
        public bool Authenticate(string _Password) 
        {
            return (Password == _Password);
        }
        public double GetAccountBalance()
        {
            return AccountBalance;
        }
        public double ModifyAccountBalance(double ModifyBy)
        {
            AccountBalance += ModifyBy;
            return AccountBalance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}