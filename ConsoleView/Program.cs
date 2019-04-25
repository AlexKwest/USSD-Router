using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UssdLibrary;
using UssdLibrary.Model;
using System.Collections;
using UssdLibrary.Controller;
using System.IO;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TestData

            Router routersModel = new Router(
                "127.0.0.1",
                "123",
                "GSM1",
                "Ярославский",
                new Typecontract
                {
                    BeelineSlot = new Beeline { MinBalance = "100", RegexBalance = "[0-9]" },
                    MegafonSlot = new Megafon { MinBalance = "100", RegexBalance = "[0-9]" },
                    MTSSlot = new MTS { MinBalance = "100", RegexBalance = "[0-9]" },
                    Tele2Slot = new Tele2 { MinBalance = "100", RegexBalance = "[0-9]" }
                },
                new Modelslot
                {
                    Lines = new SotOperator[]
                    {
                        SotOperator.Beeline,
                        SotOperator.Megafon
                    }
                });

            Router routersModel2 = new Router(
                "127.0.0.2",
                "123",
                "GSM1",
                "Ярославский",
                new Typecontract
                {
                    BeelineSlot = new Beeline { MinBalance = "100", RegexBalance = "[0-9]" },
                    MegafonSlot = new Megafon { MinBalance = "100", RegexBalance = "[0-9]" },
                    MTSSlot = new MTS { MinBalance = "100", RegexBalance = "[0-9]" },
                    Tele2Slot = new Tele2 { MinBalance = "100", RegexBalance = "[0-9]" }
                },
                new Modelslot
                {
                    Lines = new SotOperator[]
                    {
                                    SotOperator.Megafon,
                                    SotOperator.Megafon
                    }
                });

            Router routersModel3 = new Router(
                "127.0.0.3",
                "123",
                "GSM1",
                "Ярославский",
                new Typecontract
                {
                    BeelineSlot = new Beeline { MinBalance = "100", RegexBalance = "[0-9]" },
                    MegafonSlot = new Megafon { MinBalance = "100", RegexBalance = "[0-9]" },
                    MTSSlot = new MTS { MinBalance = "100", RegexBalance = "[0-9]" },
                    Tele2Slot = new Tele2 { MinBalance = "100", RegexBalance = "[0-9]" }
                },
                new Modelslot
                {
                    Lines = new SotOperator[]
                    {
                                    SotOperator.Megafon,
                                    SotOperator.Megafon
                    }
                });

            Router routersModel4 = new Router(
               "127.0.0.4",
               "123",
               "GSM1",
               "Ярославский",
               new Typecontract
               {
                   BeelineSlot = new Beeline { MinBalance = "100", RegexBalance = "[0-9]" },
                   MegafonSlot = new Megafon { MinBalance = "100", RegexBalance = "[0-9]" },
                   MTSSlot = new MTS { MinBalance = "100", RegexBalance = "[0-9]" },
                   Tele2Slot = new Tele2 { MinBalance = "100", RegexBalance = "[0-9]" }
               },
               new Modelslot
               {
                   Lines = new SotOperator[]
                   {
                                    SotOperator.Megafon,
                                    SotOperator.Megafon
                   }
               });

            Router routersModel5 = new Router(
               "127.0.0.5",
               "123",
               "GSM1",
               "Ярославский",
               new Typecontract
               {
                   BeelineSlot = new Beeline { MinBalance = "100", RegexBalance = "[0-9]" },
                   MegafonSlot = new Megafon { MinBalance = "100", RegexBalance = "[0-9]" },
                   MTSSlot = new MTS { MinBalance = "100", RegexBalance = "[0-9]" },
                   Tele2Slot = new Tele2 { MinBalance = "100", RegexBalance = "[0-9]" }
               },
               new Modelslot
               {
                   Lines = new SotOperator[]
                   {
                                    SotOperator.Megafon,
                                    SotOperator.Megafon
                   }
               });

            Contract contract = new Contract("ПирсКлиник", new List<Router> { routersModel , routersModel2 });
            Contract contract2 = new Contract("ПроКлиник", new List<Router> { routersModel5, routersModel4 });
            #endregion

            Console.WriteLine("Введите имя контракта");
            string contractName = "ПирсКлиник";

            ContractController modelNew = new ContractController(contractName);
            modelNew.AddNewRouter(routersModel3.IP, routersModel3.Password, routersModel3.NameGSM, routersModel3.OktellServer, routersModel3.TypeContracts, routersModel3.ModelSlots);

            modelNew.Add(contract2);
            foreach(var item in modelNew.Contracts)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
