using Microsoft.VisualStudio.TestTools.UnitTesting;
using UssdLibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.Fail();
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