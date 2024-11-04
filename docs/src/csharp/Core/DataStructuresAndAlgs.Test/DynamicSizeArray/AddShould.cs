namespace AndrasCsanyi.DataStructuresAndAlgs.Test.DynamicSizeArray;

using DataStructuresAndAlgs.DynamicSizeArray;
using FluentAssertions;

public class AddShould
{
    [Fact]
    public void AddElem()
    {
        DynamicSizeArray<int> su = new();
        su.Add(11);

        su.Count().Should().Be(1);
        su.StorageSize().Should().Be(8);
        for (int i = 0; i < su.Count(); i++)
        {
            su.Get(i).Should().Be(11);
        }
    }

    [Fact]
    public void AddElem_AndIncreaseStorageIfNeeded()
    {
        DynamicSizeArray<int> su = new();
        int[] testData = { 0, 1, 2, 3, 4, 5, 6, 7, };
        for (int i = 0; i < testData.Length; i++)
        {
            su.Add(testData[i]);
        }

        su.Count().Should().Be(8);
        su.StorageSize().Should().Be(8);

        su.Add(8);
        su.Count().Should().Be(9);
        su.StorageSize().Should().Be(16);
    }
}