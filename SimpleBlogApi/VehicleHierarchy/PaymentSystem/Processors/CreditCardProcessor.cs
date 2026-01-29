using PaymentSystem.Interfaces;
using PaymentSystem.Logging;

namespace PaymentSystem.Processors
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Credit Card payment of ${amount}");
            TransactionLogger.Log($"Credit Card payment: ${amount}");
        }
    }
}
