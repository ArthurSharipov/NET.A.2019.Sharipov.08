using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankAccountTask.Account
{
    class AccountStorage
    {
        /// <summary>
        /// Reads data from a file to a list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List of accounts.</returns>
        public IEnumerable<BankAccount> ReadBankAccounts(string path)
        {
            var bankAccounts = new List<BankAccount>();
            using (var binaryReader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    var bankAccount = Reader(binaryReader);
                    bankAccounts.Add(bankAccount);
                }
            }

            return bankAccounts;
        }

        /// <summary>
        /// Reads account data.
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        private static BankAccount Reader(BinaryReader binaryReader)
        {
            var accountNumber = binaryReader.ReadInt64();
            var ownerName = binaryReader.ReadString();
            var ownerLastname = binaryReader.ReadString();
            var accountBalance = binaryReader.ReadDouble();
            var accountBonus = binaryReader.ReadInt32();
            var accountStatus = binaryReader.ReadString();
            var accountType = binaryReader.ReadString();

            return new BankAccount()
            {
                AccountNumber = accountNumber,
                OwnerName = ownerName,
                OwnerLastname = ownerLastname,
                AccountBalance = accountBalance,
                AccountBonus = accountBonus,
                Status = (AccountStatus)Enum.Parse(typeof(AccountStatus), accountStatus),
                Type = (AccountType)Enum.Parse(typeof(AccountType), accountType),
            };
        }

        /// <summary>
        /// Writes account data to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bankAccounts"></param>
        public void WriteBankAccounts(string path, IEnumerable<BankAccount> bankAccounts)
        {
            using (var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var bankAccount in bankAccounts)
                    Writer(binaryWriter, bankAccount);
            }
        }

        /// <summary>
        /// Writes account data to a file.
        /// </summary>
        /// <param name="binaryWriter"></param>
        /// <param name="bankAccounts"></param>
        private static void Writer(BinaryWriter binaryWriter, BankAccount bankAccounts)
        {
            binaryWriter.Write(bankAccounts.AccountNumber);
            binaryWriter.Write(bankAccounts.OwnerName);
            binaryWriter.Write(bankAccounts.OwnerLastname);
            binaryWriter.Write(bankAccounts.AccountBalance);
            binaryWriter.Write(bankAccounts.AccountBonus);
            binaryWriter.Write(bankAccounts.Status.ToString());
            binaryWriter.Write(bankAccounts.Type.ToString());
        }
    }
}
