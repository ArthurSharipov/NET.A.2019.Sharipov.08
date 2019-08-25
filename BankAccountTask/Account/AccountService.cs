using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccountTask.Account
{
    class AccountService
    {
        List<BankAccount> bankAccounts = new List<BankAccount>();
        AccountStorage accountStorage = new AccountStorage();
        string _path;

        public AccountService(string path)
        {
            _path = path;
        }

        public void CreateAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
                throw new ArgumentNullException();

            bankAccounts.Add(bankAccount);
            accountStorage.WriteBankAccounts(_path, bankAccounts);
        }

        public void CloseAccount(long accountNumber)
        {
            if (accountNumber < 0 && accountNumber > long.MaxValue)
                throw new ArgumentException();

            var bankAccounts = FindAccount(accountNumber);
            bankAccounts.Status = AccountStatus.Close;
        }

        public BankAccount FindAccount(long accountNumber)
        {
            bankAccounts = accountStorage.ReadBankAccounts(_path) as List<BankAccount>;
            return bankAccounts.FirstOrDefault(bankAccount => bankAccount.AccountNumber == accountNumber);
        }

        public void AddAccountBalance(long accountNumber, double balance)
        {
            var bankAccounts = FindAccount(accountNumber);
            if (bankAccounts.Status == AccountStatus.Close)
                throw new ArgumentException();

            bankAccounts.AccountBalance += balance;

            if (bankAccounts.Type == AccountType.Base)
                bankAccounts.AccountBonus += 10;
            if (bankAccounts.Type == AccountType.Gold)
                bankAccounts.AccountBonus += 20;
            if (bankAccounts.Type == AccountType.Platinum)
                bankAccounts.AccountBonus += 30;

            accountStorage.WriteBankAccounts(_path, this.bankAccounts);
        }

        public void SubtractBalance(long accountNumber, double balance)
        {
            var bankAccounts = FindAccount(accountNumber);
            if (bankAccounts.Status == AccountStatus.Close)
                throw new ArgumentException();

            bankAccounts.AccountBalance -= balance;
            accountStorage.WriteBankAccounts(_path, this.bankAccounts);
        }

        public void ShowBankAccount(IEnumerable<BankAccount> bankAccounts)
        {
            foreach (var item in bankAccounts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
}
