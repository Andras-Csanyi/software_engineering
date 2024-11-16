
namespace AndrasCsanyi.DataStructuresAndAlgs.Test.DynamicSizeArray;


using AndrasCsanyi.DataStructuresAndAlgs.DynamicSizeArray;

using FluentAssertions;

public class RemoveAtShould
{

    [Fact]
    public void RemoveSuccessfullyTheFirstItem()
    {
        // Arrange
        DynamicSizeArray<int> sut = new();
        sut.Add(0);
        sut.Add(1);
        sut.Add(2);
        sut.Add(3);

        // Act
        sut.RemoveAt(0);

        // Assert
        sut.Get(0).Should().Be(1);
        sut.Get(1).Should().Be(2);
        sut.Get(2).Should().Be(3);
        sut.Count().Should().Be(3);
    }

    [Fact]
    public void RemoveSuccessfullyTheLastItem()
    {
        // Arrange
        DynamicSizeArray<int> sut = new();
        sut.Add(0);
        sut.Add(1);
        sut.Add(2);
        sut.Add(3);

        // Act
        sut.RemoveAt(3);

        // Assert
        sut.Get(0).Should().Be(0);
        sut.Get(1).Should().Be(1);
        sut.Get(2).Should().Be(2);
        sut.Count().Should().Be(3);
    }

    [Fact]
    public void RemoveSuccessfullyAnItemFromTheMiddle()
    {
        // Arrange
        DynamicSizeArray<int> sut = new();
        sut.Add(0);
        sut.Add(1);
        sut.Add(2);
        sut.Add(3);

        // Act
        sut.RemoveAt(2);

        // Assert
        sut.Get(0).Should().Be(0);
        sut.Get(1).Should().Be(1);
        sut.Get(2).Should().Be(3);
        sut.Count().Should().Be(3);
    }
}
