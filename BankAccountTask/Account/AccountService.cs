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

        /// <summary>
        /// Gets the path to file storage.
        /// </summary>
        /// <param name="path"></param>
        public AccountService(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Creates an account.
        /// </summary>
        /// <param name="bankAccount"></param>
        public void CreateAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
                throw new ArgumentNullException();

            bankAccounts.Add(bankAccount);
            accountStorage.WriteBankAccounts(_path, bankAccounts);
        }

        /// <summary>
        /// Closes an account.
        /// </summary>
        /// <param name="accountNumber"></param>
        public void CloseAccount(long accountNumber)
        {
            if (accountNumber < 0 && accountNumber > long.MaxValue)
                throw new ArgumentException();

            var bankAccounts = FindAccount(accountNumber);

            if (bankAccounts.AccountBalance < 0)
                throw new ArgumentException();

            bankAccounts.Status = AccountStatus.Close;
            accountStorage.WriteBankAccounts(_path, this.bankAccounts);
        }

        /// <summary>
        /// Find an account.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Account.</returns>
        public BankAccount FindAccount(long accountNumber)
        {
            bankAccounts = accountStorage.ReadBankAccounts(_path) as List<BankAccount>;
            return bankAccounts.FirstOrDefault(bankAccount => bankAccount.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Credits a certain amount to the account.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="balance"></param>
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

        /// <summary>
        /// Charges a certain amount to the account.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="balance"></param>
        public void SubtractBalance(long accountNumber, double balance)
        {
            var bankAccounts = FindAccount(accountNumber);
            if (bankAccounts.Status == AccountStatus.Close)
                throw new ArgumentException();

            bankAccounts.AccountBalance -= balance;
            accountStorage.WriteBankAccounts(_path, this.bankAccounts);
        }

        /// <summary>
        /// Displays the amount in the account.
        /// </summary>
        /// <param name="bankAccounts"></param>
        public void DisplayBankAccount(IEnumerable<BankAccount> bankAccounts)
        {
            foreach (var item in bankAccounts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
}