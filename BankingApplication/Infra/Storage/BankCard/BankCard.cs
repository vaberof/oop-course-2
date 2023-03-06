using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Infra.Storage.BankCard
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
        public DateTime DateCreate;
        public DateTime DateUpdate;
        public DateTime DateDelete;
        
        public BankCard(
            string owner, 
            int number, 
            int pinCode, 
            int cvc, 
            int balance, 
            int clientPassportNumber, 
            string status,
            string bankName,
            DateTime validityPeriod,
            DateTime dateCreate,
            DateTime dateUpdate,
            DateTime dateDelete)
        {
            Owner = owner;
            Number = number;
            PinCode = pinCode;
            Cvc = cvc;
            Balance = balance;
            ClientPassportNumber = clientPassportNumber;
            Status = status;
            BankName = bankName;
            ValidityPeriod = validityPeriod;
            DateCreate = dateCreate;
            DateUpdate = dateUpdate;
            DateDelete = dateDelete;
        }
    }
}
