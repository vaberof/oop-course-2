using BankingApplication.Domain.CashMachine;
using BankingApplication.Infra.Storage.CashMashine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Handler
{
    internal class ConsoleHandler
    {
        private Domain.ICashMachineService cashMachineService;

        public ConsoleHandler(Domain.ICashMachineService cashMachineService)
        {
            this.cashMachineService = cashMachineService;
        }

        public void Run()
        {
            try
            {
                int cashMachineId = init();

                while (true)
                {
                    handleCommands(cashMachineId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Run();
            }
        }

        private void handleCommands(int cashMachineId)
        {
            try
            {    
                
                Console.WriteLine("Введите команду");
                string comand = Console.ReadLine();
                
                handleCommand(comand, cashMachineId);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                return;
            }            
        }        

        private void handleCommand(string command, int cashMachineId)
        {
            switch (command)
            {
                case ConsoleCommands.ListCashMachines:
                    printAllCashMachines();
                    break;
                case ConsoleCommands.GetAvailableBanknotes:
                    printAvailableBanknotes(cashMachineId);
                    break;
                case ConsoleCommands.Exit:
                    Console.Clear();
                    Run();
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }

        private int init()
        {
            printAllCashMachines();

            Console.WriteLine("Выберите Id банкомата");
            int cashMachineId = int.Parse(Console.ReadLine());

            Domain.CashMachine.CashMachine cashMachine = cashMachineService.GetCacheMachine(cashMachineId);
            cashMachine.CheckCashMachineStatus();

            return cashMachineId;
        }

        private void printAllCashMachines()
        {
            Console.WriteLine("Доступные банкоматы:");

            List<Domain.CashMachine.CashMachine> cashMachines = cashMachineService.GetAvailableCashMachines();

            for (int i = 0; i < cashMachines.Count(); i++)
            {
                Console.WriteLine(cashMachines[i].CashMachineToString());
            }            
        }

        private void printAvailableBanknotes(int cashMachineId)
        {
            Console.WriteLine("Доступные Банкноты:");

            Dictionary<int, int> availableBanknotes = cashMachineService.GetAvailableBanknotes(cashMachineId);

            foreach (var pair in availableBanknotes)
            {
                Console.WriteLine($"Банкнота: {pair.Key},  Количество: {pair.Value}");
            }
        }
    }
}
