using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreClientTest
{
    [TestClass]
    public class StoreClientFixture
    {
        
        [TestMethod]
        public void S1_Successful()
        {
            var storeClient = new StoreClient.StoreClient();

            storeClient.StoreRequest("I1");
            Assert.AreEqual("S1 utfört", storeClient.StoreRequest("S1"));
        }

        [TestMethod]
        public void S1_Not_Successful_If_No_Items_In_Inventory()
        {
            var storeClient = new StoreClient.StoreClient();

            Assert.IsTrue(storeClient.StoreRequest("S1").Contains("Ogiltig förfrågan"));
        }

        [TestMethod]
        public void InvalidInput()
        {
            var storeClient = new StoreClient.StoreClient();

            Assert.AreEqual("Ogiltig förfrågan: L1", storeClient.StoreRequest("L1"));
        }

        [TestMethod]
        public void Ending_Program()
        {
            var storeClient = new StoreClient.StoreClient();

            Assert.AreEqual("Programmet avslutas...", storeClient.StoreRequest("E"));
        }

        [TestMethod]
        public void I1_Successfull()
        {
            var storeClient = new StoreClient.StoreClient();

            Assert.AreEqual("I1 utfört", storeClient.StoreRequest("I1"));
        }

        [TestMethod]
        public void L_Successfull()
        {
            var storeClient = new StoreClient.StoreClient();

            Assert.AreEqual("Lagersaldo: 0", storeClient.StoreRequest("L"));
        }
    }
}
