namespace PaymentSystem.Logging
{
    public static class TransactionLogger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
