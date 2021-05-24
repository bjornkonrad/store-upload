namespace Store
{
    public interface IItemInventory
    {
        public void IncreaseInventory(int amount);

        public void DecreaseInventory(int amount);

        public int GetBalance();
    }
}