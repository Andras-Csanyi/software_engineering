namespace DSA.Practice.Tests.Unit.IntervalMerge;

using FluentAssertions;
using Practice.IntervalMerge;
using Xunit;

public partial class IntervalMergeShould
{
    [Fact]
    public void SimpleOverlapping()
    {
        // Arrange
        List<Interval> intervals = new List<Interval>
        {
            new Interval { Start = 6, End = 10 },
            new Interval { Start = 1, End = 4 },
            new Interval { Start = 3, End = 6 }
        };

        // Act
        List<Interval> result = _sut.MergeOverlappingIntervals(intervals);

        // Assert
        result.Count.Should().Be(1);
        result.First().Start.Should().Be(1);
        result.First().End.Should().Be(10);
    }
}