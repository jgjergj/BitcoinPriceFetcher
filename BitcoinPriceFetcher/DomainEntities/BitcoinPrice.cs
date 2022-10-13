namespace BitcoinPriceFetcher.DomainEntities
{
    public class BitcoinPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ProviderName { get; set; }
    }
}
