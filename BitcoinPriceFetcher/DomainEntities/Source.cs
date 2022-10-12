namespace BitcoinPriceFetcher.DomainEntities
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Endpoint { get; set; }
        public string? DocumentationLink { get; set; }
    }
}
