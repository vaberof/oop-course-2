using BankingApplication.Domain.BankCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Domain.CashMachine
{
    internal interface IBankStorage : ICashMachineStorage, IBankCardStorage
    {
    }
}
