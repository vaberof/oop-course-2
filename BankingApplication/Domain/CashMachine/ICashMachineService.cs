using BankingApplication.Domain.BankCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Domain
{
    internal interface ICashMachineService
    {
        CashMachine.CashMachine GetCacheMachine(int cashMachineId);
        BankCard.BankCard AuthenticateBankCard(string bankName, int cardNumber, int cvc, int pinCode);
        List<CashMachine.CashMachine> GetAvailableCashMachines();
        Dictionary<int, int> GetAvailableBanknotes(int CacheMachineId);
    }
}
