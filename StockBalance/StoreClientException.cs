using System;

namespace StoreClient
{
    public class StoreClientException : Exception
    {
        public StoreClientException(string message) :base(message)
        {
            
        }
    }
}