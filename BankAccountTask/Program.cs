using BankAccountTask.Account;
using System;

namespace BankAccountTask
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService accountService = new AccountService(@"R:\states.txt");
            AccountStorage accountStorage = new AccountStorage();

            accountService.CreateAccount(new BankAccount(1337, "OwnerName1", "OwnerLastname1", 13.37, 13, AccountType.Base));
            accountService.CreateAccount(new BankAccount(1608, "OwnerName2", "OwnerLastname2", 16.08, 16, AccountType.Gold));
            accountService.CreateAccount(new BankAccount(1213, "OwnerName3", "OwnerLastname3", 1213, 12, AccountType.Platinum));

            Console.WriteLine(accountService.FindAccount(1337));

            accountService.CloseAccount(1337);
            accountService.DisplayBankAccount(accountStorage.ReadBankAccounts(@"R:\states.txt"));

            accountService.AddAccountBalance(1608, 58.64);
            accountService.DisplayBankAccount(accountStorage.ReadBankAccounts(@"R:\states.txt"));

            accountService.SubtractBalance(1213, 68.26);
            accountService.DisplayBankAccount(accountStorage.ReadBankAccounts(@"R:\states.txt"));

            accountService.CloseAccount(1337);
            accountService.DisplayBankAccount(accountStorage.ReadBankAccounts(@"R:\states.txt"));
        }
    }
}
