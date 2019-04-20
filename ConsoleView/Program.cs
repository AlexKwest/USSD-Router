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
            Contract contract = new Contract("ФитКлиник", new Router[] { routersModel , routersModel2 });
            Contract contract2 = new Contract("ПроКлиник", new Router[] { routersModel2, routersModel });
            #endregion
            ContractListController model = new ContractListController(new Contract[] { contract, contract2 });
            model.Add(contract2);
            model.Save();
           // model.ClearSetting();
            


            //foreach (var item in routersModelDeserialized.Contracts)
            //{
            //    foreach (var result in item.Routers)
            //    {
            //        Console.WriteLine($"{result.IP}");
            //    }

            //}


            //Console.WriteLine(routersModelDeserialized.Routers[0].IP);
            Console.ReadLine();
        }
    }
}
