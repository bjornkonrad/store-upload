
namespace Store
{
    public class StandardItemInventory : IItemInventory
    {
        private int itemCount;

        public StandardItemInventory()
        {
            itemCount = 0;
        }

        public void IncreaseInventory(int amount)
        {
            if (amount > 0)
            {
                itemCount += amount;
                return;
            }

            throw new StoreException("antal måste vara större än 0");
            
        }

        public int GetBalance()
        {
            return itemCount;
        }

        public void DecreaseInventory(int amount)
        {
            if (amount > 0)
            {
                if (amount <= GetBalance())
                {
                    itemCount -= amount;
                }
                else
                {
                    throw new StoreException("Kan inte sälja mer än vad som finns i lager");
                }

            }
            else
            {
                throw new StoreException("antal måste vara större än 0");
            }
        }
    }
}
