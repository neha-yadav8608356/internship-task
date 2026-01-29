using PaymentSystem.Interfaces;
using PaymentSystem.Logging;

namespace PaymentSystem.Processors
{
    public class CryptoProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Crypto payment of ${amount}");
            TransactionLogger.Log($"Crypto payment: ${amount}");
        }
    }
}
