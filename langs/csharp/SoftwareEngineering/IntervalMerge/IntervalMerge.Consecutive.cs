namespace AndrasCsanyi.SoftwareEngineering.IntervalMerge;

using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public partial class IntervalMergeShould
{
    private readonly IntervalMerge _sut;

    public IntervalMergeShould(ITestOutputHelper testOutputHelper)
    {
        _sut = new IntervalMerge(testOutputHelper);
    }

    [Fact]
    public void Simple()
    {
        // Arrange
        List<Interval> intervals = new List<Interval>
        {
            new Interval { Start = 7, End = 10 },
            new Interval { Start = 1, End = 3 },
            new Interval { Start = 4, End = 6 }
        };

        // Act
        List<Interval> result = _sut.MergeConsecutiveIntervals(intervals);

        // Assert
        result.Count.Should().Be(1);
        result.First().Start.Should().Be(1);
        result.First().End.Should().Be(10);
    }

    [Fact]
    public void Simple2()
    {
        // Arrange
        List<Interval> intervals = new List<Interval>
        {
            new Interval { Start = 7, End = 10 },
            new Interval { Start = 1, End = 3 },
            new Interval { Start = 5, End = 6 }
        };

        // Act
        List<Interval> result = _sut.MergeConsecutiveIntervals(intervals);

        // Assert
        result.Count.Should().Be(2);
        result[0].Start.Should().Be(1);
        result[0].End.Should().Be(3);
        result[1].Start.Should().Be(5);
        result[1].End.Should().Be(10);
    }
}