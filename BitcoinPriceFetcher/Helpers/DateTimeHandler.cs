namespace BitcoinPriceFetcher.Helpers
{
    public static class DateTimeHandler
    {
        public static DateTime ParseTimestamp(string timestamp)
        {
            long ticks = 0;
            long.TryParse(timestamp, out ticks);

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ticks);
            DateTime dateTime = dateTimeOffset.DateTime;

            return dateTime;
        }
    }
}
