using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitcoinPriceFetcher;

namespace ApiTests
{
    [TestClass]
    public class BitcoinFetcherApiTests
    {
        [TestMethod]
        [DataRow("123")]
        [DataRow("123.12345")]
        [DataRow("abcd")]
        public void GetReadableValue_Returns_TwoDecimalPlaces(string value)
        {
            decimal testCase;
            decimal.TryParse(value, out testCase);
            string testString = testCase.ToString("0.00");

            var res = BitcoinPriceFetcher.Helpers.PriceHandler.GetReadableValue(testCase);

            Assert.AreEqual(res, testString);
        }
    }
}