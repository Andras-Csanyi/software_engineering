namespace DSA.Practice.Tests.Unit.SlidingWindow.FindTheCheapest;

using sliding_window.FindTheCheapest;
using Xunit;
using Xunit.Abstractions;

public class DateInForLoopShould
{
    private readonly FindTheCheapestSell _sut;

    public DateInForLoopShould(ITestOutputHelper testOutputHelper)
    {
        _sut = new FindTheCheapestSell(testOutputHelper);
    }

    [Fact]
    public void stepThrough()
    {
        // Act
        var res = _sut.Find(
            new List<SellRecord>(),
            DateTime.Today,
            DateTime.Today.AddDays(10),
            1);
    }
}