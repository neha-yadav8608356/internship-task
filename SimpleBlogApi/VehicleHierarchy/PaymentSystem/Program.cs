using PaymentSystem.Factory;
using PaymentSystem.Interfaces;

class Program
{
    static void Main()
    {
        string[] paymentTypes = { "CreditCard", "PayPal", "Crypto" };
        decimal amount = 100.50M;

        foreach (var type in paymentTypes)
        {
            IPaymentProcessor processor = PaymentFactory.GetProcessor(type);
            processor.ProcessPayment(amount);
            Console.WriteLine();
        }

        // Example: Handling invalid type
        try
        {
            IPaymentProcessor invalidProcessor = PaymentFactory.GetProcessor("Cash");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

