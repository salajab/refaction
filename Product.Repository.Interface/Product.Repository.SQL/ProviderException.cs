using System;

namespace Product.Repository.SQL
{
    public class ProviderException : Exception
    {
        public ProviderException(string message) : base(message)
        {
        }

        public ProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
