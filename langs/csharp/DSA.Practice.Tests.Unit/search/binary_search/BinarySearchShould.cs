namespace DSA.Practice.Tests.Unit.search.binary_search;

using FluentAssertions;
using Practice.search.binary_search;
using Xunit;
using Xunit.Abstractions;

public class BinarySearchShould
{
    private readonly BinarySearch _sut;

    public BinarySearchShould(ITestOutputHelper testOutputHelper)
    {
        _sut = new BinarySearch(testOutputHelper);
    }


    public static TheoryData<(List<int>, int, int)> FindTestData =>
        new TheoryData<(List<int>, int, int)>()
        {
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, 0),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, 1),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, 2),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4, 3),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, 4),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6, 5),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7, 6),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 8, 7),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9, 8),
            (new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, 9),
        };

    [Theory]
    [MemberData(nameof(FindTestData))]
    public void Find((List<int>, int, int) i)
    {
        // Act
        int result = _sut.Find(i.Item1, i.Item2);

        // Assert
        result.Should().Be(i.Item3);
    }
}