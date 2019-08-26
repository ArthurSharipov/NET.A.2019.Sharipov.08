using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountTask.Account
{
    class BankAccount
    {
        public BankAccount()
        {
        }

        /// <summary>
        /// Assigns some values to properties.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="ownerName"></param>
        /// <param name="ownerLastname"></param>
        /// <param name="accountBalance"></param>
        /// <param name="accountBonus"></param>
        /// <param name="accountType"></param>
        public BankAccount(long accountNumber, string ownerName, string ownerLastname, double accountBalance,
            int accountBonus, AccountType accountType)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            OwnerLastname = ownerLastname;
            AccountBalance = accountBalance;
            AccountBonus = accountBonus;
            Status = AccountStatus.Active;
            Type = accountType;
        }

        public long AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastname { get; set; }
        public double AccountBalance { get; set; }
        public int AccountBonus { get; set; }
        public AccountStatus Status { get; set; }
        public AccountType Type { get; set; }

        /// <summary>
        /// Override to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"AccountNumber: {AccountNumber}, OwnerName: {OwnerName}, " +
            $"OwnerLastname: {OwnerLastname}, AccountBalance: {AccountBalance}, AccountBonus: {AccountBonus}, " +
            $"AccountStatus: {Status}, AccountType: {Type}";
    }
}
