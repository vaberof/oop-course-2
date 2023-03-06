using BankingApplication.Domain.BankCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Domain.CashMachine
{
    internal class CashMachineService : ICashMachineService
    {
        //private ICacheMachineStorage cashMachineStorage;
        //private IBankCardStorage bankCardStorage;

        private IBankStorage bankStorage;
        public CashMachineService(IBankStorage bankStorage)
        {
            //this.cashMachineStorage = cashMachineStorage;
            //this.bankCardStorage = bankCardStorage;
            this.bankStorage = bankStorage;
        }

        public List<CashMachine> GetAvailableCashMachines()
        {
            List<CashMachine> cashMachines = new List<CashMachine>();

            cashMachines = bankStorage.GetCacheMachines();
            if (cashMachines == null)
            {
                throw new Exception("Нет доступных банкоматов");
            }

            return cashMachines;
        }

        public Dictionary<int, int> GetAvailableBanknotes(int CacheMachineId)
        {
            Dictionary<int, int> availableBanknotes = bankStorage.GetAvailableBanknotes(CacheMachineId);
            if (availableBanknotes == null)
            {
                throw new Exception("Невозмоэно получить информацию о доступных банкнотах");
            }

            return availableBanknotes;
        }

        public CashMachine GetCacheMachine(int cashMachineId)
        {
            CashMachine cashMachine = bankStorage.GetCacheMachine(cashMachineId);

            if (cashMachine == null)
            {
                throw new Exception("Не удалось найти банкомат с данным id");
            }

            return cashMachine;
        }

        public BankCard.BankCard AuthenticateBankCard(string bankName, int cardNumber, int cvc, int pinCode)
        {
            BankCard.BankCard bankCard = bankStorage.GetBankCard(cardNumber, cvc, bankName);

            if (bankCard == null)
            {
                throw new Exception("Банковская карта не найдена");
            }

            validateBankCardPinCode(bankCard.PinCode, pinCode);
            validateBankCardStatus(bankCard.Status);
            validateBankCardBankName(bankName, bankCard.BankName);
            validateBankCardValidityPeriod(bankCard.ValidityPeriod);

            return bankCard;
        }

        /*public BankCard.BankCard DepositFunds(BankCard.BankCard bankCard, int funds, count)
        {

            return bankCard;
        }*/

        /*public BankCard.BankCard WithdrawFunds(BankCard.BankCard bankCard, int funds)
        {
            if (bankCard.Balance < funds)
            {
                throw new Exception("Недостаточно средств для вывода");
            }

            try
            {
                bankCardStorage.WithdrawFunds(bankCard.Number, bankCard.Cvc, bankCard.BankName);
            }
            catch
            {
                
            }
            
            return bankCard;
        }*/

        public double GetBalance(BankCard.BankCard bankCard)
        {
            return bankCard.Balance;
        }

        private void validateBankCardPinCode(int pinCode, int inputPinCode)
        {
            if (pinCode != inputPinCode)
            {
                throw new Exception("Неверный пин-код");
            }
        }

        private void validateBankCardStatus(string status)
        {
            if (status != BankCardStatus.Ok)
            {
                switch (status)
                {
                    case BankCardStatus.Locked:
                        throw new Exception("Карта заблокирована");
                    default:
                        throw new Exception("Неизвестный статус у банкомата");
                }
            }
        }

        private void validateBankCardBankName(string bankName, string cardBankBankName)
        {
            if (bankName != cardBankBankName)
            {
                throw new Exception("Банкомат не принимает карты Вашего банка");
            }
        }

        private void validateBankCardValidityPeriod(DateTime validityPeriod)
        {
            DateTime currentDate = DateTime.Now;

            if (currentDate > validityPeriod)
            {
                throw new Exception("У Вашей карты истек срок действия");
            }
        }

    }
}
