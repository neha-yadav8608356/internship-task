using PaymentSystem.Interfaces;
using PaymentSystem.Processors;

namespace PaymentSystem.Factory
{
    public static class PaymentFactory
    {
        public static IPaymentProcessor GetProcessor(string type)
        {
            return type.ToLower() switch
            {
                "creditcard" => new CreditCardProcessor(),
                "paypal" => new PayPalProcessor(),
                "crypto" => new CryptoProcessor(),
                _ => throw new ArgumentException("Invalid payment type")
            };
        }
    }
}
