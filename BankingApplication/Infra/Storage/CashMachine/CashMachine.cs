using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Infra.Storage.CashMashine
{
    internal class CashMachine
    {
        public int Id;
        public Dictionary<int, int> AvailableBanknotes;
        public string Location;
        public string Status;
        public string BankName;

        public CashMachine(int id, Dictionary<int, int> availableBanknotes, string location, string status, string bankName)
        {
            Id = id;
            AvailableBanknotes = availableBanknotes;
            Location = location;
            Status = status;
            BankName = bankName;
        }
    }
}
