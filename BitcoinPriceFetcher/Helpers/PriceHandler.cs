namespace BitcoinPriceFetcher.Helpers
{
    public static class PriceHandler
    {
        public static string GetReadableValue(decimal value)
        {
            return value.ToString("0.00");
        }
    }
}
