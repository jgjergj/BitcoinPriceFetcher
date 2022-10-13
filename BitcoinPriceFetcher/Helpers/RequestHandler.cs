namespace BitcoinPriceFetcher.Helpers
{
    public static class RequestHandler
    {
        public static async Task<string> GetDataFromProvider(string endpoint)
        {
            //todo: add validation
            using var client = new HttpClient();

            var result = await client.GetStringAsync(endpoint);

            return result;
        }
    }
}
