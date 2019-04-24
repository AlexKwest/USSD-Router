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




            Contract contract = new Contract("ФитКлиник", new Router[] { routersModel , routersModel2 });
            Contract contract2 = new Contract("ПроКлиник", new Router[] { routersModel3, routersModel4 });
            #endregion
            ContractController model = new ContractController();
            model.Add(contract2);
            model.Add(contract);

            var resultContract = model.GetContract("ФитКлиник");
            var resultRouter = model.GetRouter("127.0.0.2");

            Console.WriteLine(resultRouter);
            //foreach(var item in resultContract)
            //{
            //    Console.WriteLine(item);
            //}


            Console.ReadLine();
        }
    }
}
