namespace AndrasCsanyi.SoftwareEngineering.graphs.dfs.currency_change;

using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class ConvertAvailableExchangesShouldTest
{
    private CurrencyChange _currencyChange;

    public ConvertAvailableExchangesShouldTest(ITestOutputHelper testOutputHelper)
    {
        _currencyChange = new CurrencyChange(testOutputHelper);
    }

    [Fact]
    public void CreateBuckets_BucketsWithSingleItem()
    {
        // Arrange
        List<Exchange> availableExchanges = new List<Exchange>
        {
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "GBP" },
                Rate = new Rate { Value = 1.18m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "USD" },
                Rate = new Rate { Value = 1.41m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "NZD" },
                Rate = new Rate { Value = 1.31m }
            }
        };

        // Act
        Dictionary<string, List<Exchange>> result = _currencyChange.ConvertAvailableExchanges(availableExchanges);

        // Assert
        foreach (Exchange availableExchange in availableExchanges)
        {
            result.TryGetValue(availableExchange.FromNode.CurrencyName, out List<Exchange> items);
            Func<Exchange> f = () =>
            {
                return items.Find(
                    f => f.FromNode.CurrencyName == availableExchange.FromNode.CurrencyName
                         && f.ToNode.CurrencyName == availableExchange.ToNode.CurrencyName
                         && f.Rate.Value == availableExchange.Rate.Value);
            };
            f.Should().NotThrow();
        }
    }

    [Fact]
    public void CreateBuckets_BucketsWithMultipleItems()
    {
        // Arrange
        List<Exchange> availableExchanges = new List<Exchange>
        {
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "GBP" },
                Rate = new Rate { Value = 1.18m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "HUF" },
                Rate = new Rate { Value = 382m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "PES" },
                Rate = new Rate { Value = 143m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "USD" },
                Rate = new Rate { Value = 1.41m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "PES" },
                Rate = new Rate { Value = 211m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "HUF" },
                Rate = new Rate { Value = 211m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "NZD" },
                Rate = new Rate { Value = 1.31m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "PES" },
                Rate = new Rate { Value = 112m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "HUF" },
                Rate = new Rate { Value = 362m }
            },
        };

        // Act
        Dictionary<string, List<Exchange>> result = _currencyChange.ConvertAvailableExchanges(availableExchanges);

        // Assert
        foreach (Exchange availableExchange in availableExchanges)
        {
            if (result.TryGetValue(availableExchange.FromNode.CurrencyName, out List<Exchange> items))
            {
                availableExchanges
                    .FindAll(f => f.FromNode.CurrencyName == availableExchange.FromNode.CurrencyName)
                    .ToList()
                    .ForEach(item => { items.Contains(item).Should().BeTrue(); });
            }
            else
            {
                true.Should().BeFalse();
            }
        }
    }
}