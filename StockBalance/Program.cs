using System;
using System.Text;

namespace StoreClient
{
    class Program
    {
        static void Main(string[] args)
        {

            StoreClient p = new();
            string input = string.Empty;

            while (!input.Equals("E"))
            {
                Console.Write(StoreClient.GetInstructions());

                input = Console.ReadLine();

                Console.WriteLine(p.StoreRequest(input));
                Console.WriteLine("***********************");
            }
        }
    }
}
