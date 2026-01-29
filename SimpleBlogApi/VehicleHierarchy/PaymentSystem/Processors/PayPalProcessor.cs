using PaymentSystem.Interfaces;
using PaymentSystem.Logging;

namespace PaymentSystem.Processors
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
            TransactionLogger.Log($"PayPal payment: ${amount}");
        }
    }
}
