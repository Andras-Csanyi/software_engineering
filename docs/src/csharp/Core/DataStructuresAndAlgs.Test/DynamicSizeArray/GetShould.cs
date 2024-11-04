namespace AndrasCsanyi.DataStructuresAndAlgs.Test.DynamicSizeArray;

using DataStructuresAndAlgs.DynamicSizeArray;
using FluentAssertions;

public class GetShould
{
    [Fact]
    public void ReturnItem()
    {
        int testValue = 11;
        DynamicSizeArray<int> su = new();
        su.Add(testValue);

        su.Get(0).Should().Be(testValue);
    }

    [Fact]
    public void Throw_WhenIndexOutOfRange()
    {
        DynamicSizeArray<int> su = new();
        su.Add(11);

        su.Get(0).Should().Be(11);

        Action action = () => su.Get(1);
        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
}