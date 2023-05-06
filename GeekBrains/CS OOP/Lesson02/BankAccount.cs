using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    enum BankAccountType: ushort
    {
        None = 0,
        Debit = 1,
        Credit = 2
    }
    internal class BankAccount
    {
        private static int bankAccountEntryNo = 0;
        private int accountNumber;
        private decimal balance;
        private BankAccountType bankAccountType;
        public int AccountNumber { get; }
        public BankAccountType BankAccountType { get; }
        public Decimal Balance { get; set; }
        

    }
}
