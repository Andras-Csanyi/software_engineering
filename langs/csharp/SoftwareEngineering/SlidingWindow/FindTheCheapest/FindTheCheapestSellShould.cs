namespace AndrasCsanyi.SoftwareEngineering.SlidingWindow.FindTheCheapest;

using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class FindTheCheapestSellShould
{
    private readonly FindTheCheapestSell _sut;

    public FindTheCheapestSellShould(ITestOutputHelper testOutputHelper)
    {
        _sut = new FindTheCheapestSell(testOutputHelper);
    }

    [Fact]
    public void Simple()
    {
        // Arrange
        List<SellRecord> records = new List<SellRecord>
        {
            new SellRecord
            {
                Product = Product.Bread,
                SellPrice = 10,
                TransactionDate = new DateTime(2023, 10, 10)
            },
            new SellRecord
            {
                Product = Product.Bread,
                SellPrice = 11,
                TransactionDate = new DateTime(2023, 10, 11)
            },
            new SellRecord
            {
                Product = Product.Bread,
                SellPrice = 11,
                TransactionDate = new DateTime(2023, 10, 12)
            },
            new SellRecord
            {
                Product = Product.Bread,
                SellPrice = 10,
                TransactionDate = new DateTime(2023, 10, 13)
            },
        };

        // Act
        Dictionary<string, Dictionary<DateTime, decimal>> result = _sut.Find(
            records,
            new DateTime(2023, 10, 10),
            new DateTime(2023, 10, 14),
            2);

        // Assert
        string key1 = $"{new DateTime(2023, 10, 10)}-{new DateTime(2023, 10, 12)}";
        string key2 = $"{new DateTime(2023, 10, 12)}-{new DateTime(2023, 10, 14)}";
        result.ContainsKey(key1).Should().BeTrue();
        result.ContainsKey(key2).Should().BeTrue();

        result.TryGetValue(key1, out Dictionary<DateTime, decimal> key1Result);
        key1Result.ContainsKey(new DateTime(2023, 10, 10)).Should().BeTrue();
        key1Result.TryGetValue(new DateTime(2023, 10, 10), out decimal key1FinalResult);
        key1FinalResult.Should().Be(10);

        result.TryGetValue(key2, out Dictionary<DateTime, decimal> key2Result);
        key2Result.ContainsKey(new DateTime(2023, 10, 13)).Should().BeTrue();
        key2Result.TryGetValue(new DateTime(2023, 10, 13), out decimal key2FinalResult);
        key2FinalResult.Should().Be(10);
    }
}