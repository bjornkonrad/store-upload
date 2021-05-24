using System;
namespace Store
{
    public class Store : IStore
    {
        readonly IItemInventory standardItemInventory;

        public Store()
        {
            standardItemInventory = new StandardItemInventory();
        }

        void IStore.DeliverItem(int amount)
        {
            standardItemInventory.IncreaseInventory(amount);
        }

        int IStore.GetItemBalance()
        {
            return standardItemInventory.GetBalance();
        }

        void IStore.SellItem(int amount)
        {
            standardItemInventory.DecreaseInventory(amount);

            standardItemInventory.IncreaseInventory(amount * 2);
        }
    }
}
