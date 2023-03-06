using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Domain.BankCard
{
    internal class BankCard
    {
        public string Owner;
        public int Number;
        public int PinCode;
        public int Cvc;
        public double Balance;
        public int ClientPassportNumber;
        public string Status;
        public string BankName;
        public DateTime ValidityPeriod;

        public BankCard(string owner, int cardDumber, int pinCode, int cvc, double balance, string status, int clientPassportNumber, string bankName, DateTime validityPeriod)
        {
            Owner = owner;
            Number = cardDumber;
            PinCode = pinCode;
            Cvc = cvc;
            Balance = balance;
            ClientPassportNumber = clientPassportNumber;
            Status = status;
            BankName = bankName;
            ValidityPeriod = validityPeriod;
        }
    }
}
