using BankingApplication.Domain.BankCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankingApplication.Domain.CashMachine
{
    internal class CashMachine
    {
        private int id;
        private Dictionary<int, int> availableBanknotes;
        private string bankName;
        private string status;
        private string location;
        
        public CashMachine(int id, Dictionary<int, int> availableBanknotes, string bankName, string status, string location)
        {
            this.id = id;
            this.availableBanknotes = availableBanknotes;
            this.bankName = bankName;
            this.status = status;
            this.location = location;
        }

        public void CheckCashMachineStatus()
        {
            if (status != CashMachineStatus.Ok)
            {
                switch (status)
                {
                    case CashMachineStatus.TechnicalWork:
                        throw new Exception("Ведутся технические работы");
                    default:
                        throw new Exception("Неизвестный статус у банкомата");
                }
            }
        }

        public string CashMachineToString()
        {
            return string.Format("id: {0}, bank name: {1}, location: {2} \n", id, bankName, location);
        }
    }
}
