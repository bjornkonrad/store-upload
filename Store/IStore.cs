namespace Store
{
    public interface IStore
    {
        public void SellItem(int amount);

        public void DeliverItem(int amount);

        public int GetItemBalance();
    }
}
