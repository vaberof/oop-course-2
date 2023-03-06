using BankingApplication.Domain.CashMachine;
using BankingApplication.Handler;
using BankingApplication.Infra.Bank;
using BankingApplication.Infra.Storage.BankCard;
using BankingApplication.Infra.Storage.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            List<BankCard> bankCards = new List<BankCard>();
            List<Infra.Storage.CashMashine.CashMachine> cashMachines = new List<Infra.Storage.CashMashine.CashMachine>();

            Dictionary<int, int> banknotes = new Dictionary<int, int>
            {
                { 100, 10 },
                { 500, 30 },
                { 1000, 15 },
                { 5000, 40 }
            }; 

            cashMachines.Add(new Infra.Storage.CashMashine.CashMachine(
                1, banknotes, "Площадь Ленина", "Ok", "Сбербанк"));

            Bank bank = new Bank(clients, bankCards, cashMachines);

            CashMachineService cashMachineService = new CashMachineService(bank);

            ConsoleHandler consoleHandler = new ConsoleHandler(cashMachineService);
            consoleHandler.Run();
        }
    }
}
