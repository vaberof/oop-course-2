using BankingApplication.Domain.CashMachine;
using BankingApplication.Infra.Storage.Client;
using System.Collections.Generic;
using System.Linq;

namespace BankingApplication.Infra.Bank
{
    internal class Bank : IBankStorage //ICacheMachineStorage, IBankCardStorage
    {
        private List<Client> clients;
        private List<Storage.BankCard.BankCard> bankCards;
        private List<Storage.CashMashine.CashMachine> cashMachines;
        
        public Bank(List<Client> clients, List<Storage.BankCard.BankCard> bankCards, List<Storage.CashMashine.CashMachine> cashMachines)
        {
            this.clients = clients;
            this.cashMachines = cashMachines;
            this.bankCards = bankCards;
        }

        public List<Client> GetClients()
        {
            return clients;
        }

        public List<Storage.BankCard.BankCard> GetBankCards()
        {
            return bankCards;
        }

        public Domain.BankCard.BankCard GetBankCard(int cardNumber, int cvc, string bankName)
        {
            for (int i = 0; i < bankCards.Count; i++)
            {
                Storage.BankCard.BankCard bankCard = bankCards[i];

                if (bankCard.Number == cardNumber && bankCard.Cvc == cvc && bankCard.BankName == bankName)
                {
                    return new Domain.BankCard.BankCard(
                        bankCard.Owner, 
                        bankCard.Number,
                        bankCard.PinCode,
                        bankCard.Cvc,
                        bankCard.Balance,
                        bankCard.Status,
                        bankCard.ClientPassportNumber,
                        bankCard.BankName,
                        bankCard.ValidityPeriod);
                }
            }

            return null;
        }

        public Dictionary<int, int> GetAvailableBanknotes(int cashMachineId)
        {
            for (int i = 0; i < cashMachines.Count; i++)
            {
                Storage.CashMashine.CashMachine cashMachine = cashMachines[i];

                if (cashMachine.Id == cashMachineId)
                {
                    return cashMachine.AvailableBanknotes;
                }
            }

            return null;
        }

        public Domain.CashMachine.CashMachine GetCacheMachine(int cashMachineId)
        {        

            for (int i = 0; i < cashMachines.Count; i++)
            {
                if (cashMachines[i].Id == cashMachineId)
                {
                    return new Domain.CashMachine.CashMachine(
                        cashMachines[i].Id,
                        cashMachines[i].AvailableBanknotes,
                        cashMachines[i].BankName,
                        cashMachines[i].Status,
                        cashMachines[i].Location);
                }
            }

            return null;
        }

        public List<Domain.CashMachine.CashMachine> GetCacheMachines()
        {
            List<Domain.CashMachine.CashMachine>  domainCacheMachines = new List<Domain.CashMachine.CashMachine>();

            for (int i = 0; i < cashMachines.Count; i++)
            {
                domainCacheMachines.Add(new Domain.CashMachine.CashMachine(
                    cashMachines[i].Id,
                    cashMachines[i].AvailableBanknotes,
                    cashMachines[i].Location,
                    cashMachines[i].Status,
                    cashMachines[i].BankName));
            }

            if (!domainCacheMachines.Any())
            {
                return null;
            }

            return domainCacheMachines;
        }
    }
}
