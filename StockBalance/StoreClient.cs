using System;
using System.Text;

namespace StoreClient
{
    public class StoreClient
    {
        private readonly Store.IStore store;
        private readonly string invalidRequest = "Ogiltig förfrågan: ";
        public StoreClient()
        {
            store = new Store.Store();
        }

        public string StoreRequest(string input)
        {
            var trimmedInput = input.Trim();
            string action;
            try
            {
                 action = trimmedInput.Substring(0, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                return invalidRequest + input;
            }   

            try
            {
                switch (action)
                {
                    case "S":
                        store.SellItem(GetAmount(trimmedInput));
                        return input + " utfört";


                    case "I":
                        store.DeliverItem(GetAmount(trimmedInput));
                        return input + " utfört";

                    case "L" :
                        if (trimmedInput.Length == 1)
                        {
                            var balance = store.GetItemBalance();
                            return "Lagersaldo: " + balance;
                        }
                        break;

                    case "E":
                        if (trimmedInput.Length == 1)
                        {

                            return "Programmet avslutas...";
                        }
                        break;

                    default:
                        return invalidRequest + input;
                }
            }
            catch(StoreClientException e)
            {
                return invalidRequest + input + " " + e.Message;
            }
            catch (Exception e)
            {
                return invalidRequest + input + " " + e.Message;
            }

            return invalidRequest + input;
        }

        public static string GetInstructions()
        {
            var sb = new StringBuilder();

            sb.AppendLine("S[antal] för att registrera försäljning");
            sb.AppendLine("I[antal] för att registrera inleverans");
            sb.AppendLine("L för att se lagersaldo");
            sb.AppendLine("E för att avsluta");

            return sb.ToString();
        }

        
        private static int GetAmount(string input)
        {
            int amount;

            try
            {
                amount = int.Parse(input[1..]);
            }
            catch(FormatException)
            {
                throw new StoreClientException("antal måste vara numerisk");
            }
            catch (OverflowException)
            {
                throw new StoreClientException("lagret rymmer inte så stort antal");
            }
            return amount;
        }
    }
}