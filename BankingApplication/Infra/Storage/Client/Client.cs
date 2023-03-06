using BankingApplication.Infra.Storage.BankCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Infra.Storage.Client
{
    internal class Client
    {
        private string fullName;
        private int passportNumber;
        private List<BankCard.BankCard> bankCards;

        public Client(string fullName, int passportNumber, List<BankCard.BankCard> bankCards)
        {
            this.fullName = fullName;
            this.passportNumber = passportNumber;
            this.bankCards = bankCards;
        }
    }
}
