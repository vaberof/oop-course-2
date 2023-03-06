using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Domain.BankCard
{
    internal interface IBankCardStorage
    {
        BankCard GetBankCard(int cardNumber, int cvc, string bankName);
        //BankCard WithdrawFunds(int cardNumber, int cvc, string bankName);
    }
}
