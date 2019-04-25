using Microsoft.VisualStudio.TestTools.UnitTesting;
using UssdLibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UssdLibrary.Model;

namespace UssdLibrary.Controller.Tests
{
    [TestClass()]
    public class ContractControllerTests
    {
        [TestMethod()]
        public void ContractControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContractControllerTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddNewRouterTest()
        {
            var contractName = "ПроМед";
            var ip = "127.0.0.50";
            Router routerControl = new Router(
               ip,
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

            var controller = new ContractController(contractName);
            controller.AddNewRouter(routerControl);
            Assert.AreEqual(controller.CurrentRouter, routerControl);
        }

        [TestMethod()]
        public void AddContractTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddContractTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteRouterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteContractTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetContractTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRouterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            var contractName = Guid.NewGuid().ToString();
            var controller = new ContractController(contractName);

            Assert.AreEqual(contractName, controller.CurrentContract.NameContract);
        }

        [TestMethod()]
        public void ClearContractsTest()
        {
            Assert.Fail();
        }
    }
}