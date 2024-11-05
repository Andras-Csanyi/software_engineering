namespace AndrasCsanyi.DataStructuresAndAlgs.Test.DynamicSizeArray;

using DataStructuresAndAlgs.DynamicSizeArray;
using FluentAssertions;

public class Defaults
{
    [Fact]
    public void DefaultStorageSize()
    {
        DynamicSizeArray<int> dsa = new();
        dsa.StorageSize().Should().Be(dsa.StorageDefaultSize());
    }

    [Fact]
    public void DefaultElemSize()
    {
        DynamicSizeArray<int> dsa = new();
        dsa.Count().Should().Be(0);
    }
}