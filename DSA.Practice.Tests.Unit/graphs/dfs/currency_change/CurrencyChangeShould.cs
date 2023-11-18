namespace DSA.Practice.Tests.Unit.graphs.dfs.currency_change;

using FluentAssertions;
using Practice.graphs.dfs.currency_change;
using Xunit;
using Xunit.Abstractions;

public class CurrencyChangeShould
{
    private CurrencyChange _sut;

    public CurrencyChangeShould(ITestOutputHelper testOutputHelper)
    {
        _sut = new CurrencyChange(testOutputHelper);
    }

    [Fact]
    public void findPath_SingleTransition()
    {
        // Arrange
        List<Exchange> availableExchanges = new List<Exchange>
        {
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "GBP" },
                Rate = new Rate { Value = 1.12m }
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
                Rate = new Rate { Value = 1.34m }
            }
        };

        // Act
        decimal result = _sut.Exchange(availableExchanges, "EUR", "USD", 100);

        // Assert
        result.Should().Be(100 * 1.12m * 1.41m + (2 * 0.75m));
    }

    [Fact]
    public void findPath_ThereIsNoPath()
    {
        // Arrange
        List<Exchange> availableExchanges = new List<Exchange>
        {
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "GBP" },
                Rate = new Rate { Value = 1.12m }
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
                Rate = new Rate { Value = 1.34m }
            }
        };

        // Act
        decimal result = _sut.Exchange(availableExchanges, "EUR", "HUF", 100);

        // Assert
        result.Should().Be(-1m);
    }

    [Fact]
    public void findPath_ThreeTransitions()
    {
        // Arrange
        List<Exchange> availableExchanges = new List<Exchange>
        {
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "GBP" },
                Rate = new Rate { Value = 1.12m }
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
                ToNode = new Node { CurrencyName = "HUF" },
                Rate = new Rate { Value = 367.3m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "NZD" },
                Rate = new Rate { Value = 1.34m }
            }
        };

        // Act
        decimal result = _sut.Exchange(availableExchanges, "EUR", "HUF", 100);

        // Assert
        result.Should().Be((((100 * 1.12m) * 1.41m) * 367.3m) + (3 * 0.75m));
    }

    [Fact]
    public void findPath_ThreeTransitionsWithNoise()
    {
        // Arrange
        List<Exchange> availableExchanges = new List<Exchange>
        {
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "GBP" },
                Rate = new Rate { Value = 1.12m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "NZD" },
                Rate = new Rate { Value = 182.4m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "KRN" },
                Rate = new Rate { Value = 12.4m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "EUR" },
                ToNode = new Node { CurrencyName = "PRN" },
                Rate = new Rate { Value = 22.4m }
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
                ToNode = new Node { CurrencyName = "HUF" },
                Rate = new Rate { Value = 418.1m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "NZD" },
                Rate = new Rate { Value = 48.1m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "AUD" },
                Rate = new Rate { Value = 1.17m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "GBP" },
                ToNode = new Node { CurrencyName = "DNR" },
                Rate = new Rate { Value = 0.63m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "HUF" },
                Rate = new Rate { Value = 367.3m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "ASD" },
                Rate = new Rate { Value = 2.3m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "BSD" },
                Rate = new Rate { Value = 2.39m }
            },
            new Exchange
            {
                FromNode = new Node { CurrencyName = "USD" },
                ToNode = new Node { CurrencyName = "NZD" },
                Rate = new Rate { Value = 1.34m }
            }
        };

        // Act
        decimal result = _sut.Exchange(availableExchanges, "EUR", "HUF", 100);

        // Assert
        result.Should().Be((((100 * 1.12m) * 1.41m) * 367.3m) + (3 * 0.75m));
    }
}