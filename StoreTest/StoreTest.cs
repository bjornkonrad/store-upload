using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store;


namespace StoreClientTest
{
    [TestClass]
    public class StoreFixture
    {
        [TestMethod]
        public void Store_Initiated_With_0_Balance()
        {
            IItemInventory store = new Store.StandardItemInventory();

            Assert.AreEqual(0, store.GetBalance());
        }

        [TestMethod]
        public void Selling_1_Item_Adds_2_New_Items()
        {
            IStore store = new Store.Store();

            store.DeliverItem(1);
            store.SellItem(1);

            Assert.AreEqual(2, store.GetItemBalance());
        }

        [TestMethod]
        public void Adding_Item_To_Store_Increases_Balance_Of_Item()
        {
            IItemInventory store = new Store.StandardItemInventory();

            store.IncreaseInventory(1);

            Assert.AreEqual(1, store.GetBalance());
        }

        [TestMethod]
        public void Selling_Item_In_Store_Decreases_Balance_Of_Item()
        {
            IItemInventory store = new Store.StandardItemInventory();

            store.IncreaseInventory(2);
            store.DecreaseInventory(1);

            Assert.AreEqual(1, store.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(StoreException))]
        public void Not_Possible_To_Sell_If_Balance_Is_0_Or_Less()
        {
            IItemInventory store = new Store.StandardItemInventory();
 
            store.DecreaseInventory(1);
        }

        [TestMethod]
        [ExpectedException(typeof(StoreException))]
        public void Not_Possible_To_Sell_Negative()
        {
            IItemInventory store = new Store.StandardItemInventory();

            store.DecreaseInventory(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(StoreException))]
        public void Not_Possible_To_Sell_0()
        {
            IItemInventory store = new Store.StandardItemInventory();

            store.DecreaseInventory(0);
        }

        [TestMethod]
        [ExpectedException(typeof(StoreException))]
        public void Not_Possible_To_Add_0()
        {
            IItemInventory store = new Store.StandardItemInventory();

            store.IncreaseInventory(0);
        }

        [TestMethod]
        [ExpectedException(typeof(StoreException))]
        public void Not_Possible_To_Add_Negative()
        {
            IItemInventory store = new Store.StandardItemInventory();

            store.IncreaseInventory(-1);
        }
    }
}
