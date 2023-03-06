using BankingApplication.Infra.Storage.CashMashine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Domain.CashMachine
{
    internal interface ICashMachineStorage
    {
        CashMachine GetCacheMachine(int cashMachineId);
        List<CashMachine> GetCacheMachines();
        Dictionary<int, int> GetAvailableBanknotes(int CacheMachineId);
    }
}
