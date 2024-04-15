namespace AndrasCsanyi.SoftwareEngineering.search.binary_search;

using Xunit.Abstractions;

public class BinarySearch
{
    private readonly ITestOutputHelper _testOutputHelper;

    public BinarySearch(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    /// <summary>
    ///     Looks for the searchedElement in the provided input using binary search and returns the index.
    /// </summary>
    /// <param name="input">The <see cref="List{T}" /> of elements. It has to be sorted.</param>
    /// <param name="searchedElement">The element we want to know its index in the provided input.</param>
    /// <returns></returns>
    public int Find(List<int> input, int searchedElement)
    {
        int left = 0;
        int right = input.Count - 1;
        string msgInit = $"Start: " +
                         $"looking for: {searchedElement}, " +
                         $"left:{input[left]}, " +
                         $"right:{input[right]}";
        _testOutputHelper.WriteLine(msgInit);

        do
        {
            int mid = (left + right) / 2;
            string m = $"Searching in interval: " +
                       $"min: {input[left]}, " +
                       $"max: {input[right]}, " +
                       $"mid: {input[mid]}";
            _testOutputHelper.WriteLine(m);

            if (input[mid] == searchedElement)
            {
                _testOutputHelper.WriteLine($"FOUND! {input[mid]} at index: {mid}");
                return mid;
            }

            if (input[mid] > searchedElement)
            {
                // going left
                right = mid - 1;

                string msg = $"Going left!";
                _testOutputHelper.WriteLine(msg);
            }
            else
            {
                // going right
                left = mid + 1;
                string msg = $"Going right!";
                _testOutputHelper.WriteLine(msg);
            }
        } while (left <= right);

        _testOutputHelper.WriteLine("Element is not in the list");
        return -1;
    }
}