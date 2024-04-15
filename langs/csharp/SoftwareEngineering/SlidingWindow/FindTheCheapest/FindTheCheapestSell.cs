namespace AndrasCsanyi.SoftwareEngineering.SlidingWindow.FindTheCheapest;

using Xunit.Abstractions;

/// <summary>
///     A shop needs to process its records about selling their goods. The shop maintains it high volume of customers by
///     constant discounts. In order to measure effectiveness of these discounts they have to know the sell price of a
///     product in a short interval in a period of time.
///     <para>
///         Input:
///         <list type="bullet">
///             <item>recorded sells <see cref="SellRecord" /></item>
///             <item>period start date</item>
///             <item>period end date</item>
///             <item>interval size in days</item>
///             <item>product category</item>
///         </list>
///     </para>
///     <para>
///         Return a list showing:
///         <list type="bullet">
///             <item>interval start date</item>
///             <item>interval end date</item>
///             <item>lowest price</item>
///         </list>
///     </para>
/// </summary>
public class FindTheCheapestSell
{
    private readonly ITestOutputHelper _testOutputHelper;

    public FindTheCheapestSell(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public Dictionary<String, Dictionary<DateTime, decimal>> Find(
        List<SellRecord> sellRecords,
        DateTime start,
        DateTime end,
        int intervalLengthsInDays)
    {
        Dictionary<DateTime, List<SellRecord>> cachedSellRecords = TransformSellRecords(sellRecords);
        Dictionary<String, Dictionary<DateTime, decimal>> result = new();
        List<SellRecord> allCachedItemsForInterval = new();

        for (DateTime intervalStart = start;
             intervalStart < end;
             intervalStart = intervalStart.AddDays(intervalLengthsInDays))
        {
            SortedSet<decimal> sortedInterval = new SortedSet<decimal>();

            for (DateTime actualDayWithinInterval = intervalStart;
                 actualDayWithinInterval < intervalStart.AddDays(intervalLengthsInDays);
                 actualDayWithinInterval = actualDayWithinInterval.AddDays(1))
            {
                if (!cachedSellRecords.ContainsKey(actualDayWithinInterval))
                {
                    continue;
                }

                cachedSellRecords.TryGetValue(actualDayWithinInterval, out List<SellRecord> dailySellFromCache);
                dailySellFromCache.ForEach(itemsWithinADay => { sortedInterval.Add(itemsWithinADay.SellPrice); });
                allCachedItemsForInterval.AddRange(dailySellFromCache);
            }

            DateTime intervalEndForSearching = intervalStart.AddDays(intervalLengthsInDays);
            SellRecord cheapestRecord = allCachedItemsForInterval
                .Find(item => item.SellPrice == sortedInterval.Min
                              && item.TransactionDate >= intervalStart
                              && item.TransactionDate < intervalEndForSearching);

            if (cheapestRecord is null)
            {
                _testOutputHelper.WriteLine("Cheapest is empty");
                continue;
            }

            string intervalDateString = $"{intervalStart}-{intervalStart.AddDays(intervalLengthsInDays)}";
            result.Add(intervalDateString, new Dictionary<DateTime, decimal>
            {
                { cheapestRecord.TransactionDate, cheapestRecord.SellPrice }
            });

            _testOutputHelper.WriteLine(intervalStart.ToString());
        }

        _testOutputHelper.WriteLine(result.ToString());

        return result;
    }

    private Dictionary<DateTime, List<SellRecord>> TransformSellRecords(List<SellRecord> sellRecords)
    {
        Dictionary<DateTime, List<SellRecord>> result = new Dictionary<DateTime, List<SellRecord>>();
        sellRecords.ForEach(item =>
        {
            if (result.ContainsKey(item.TransactionDate))
            {
                result.TryGetValue(item.TransactionDate, out List<SellRecord> sellRecordsAtDate);
                sellRecordsAtDate.Add(item);
                result.Remove(item.TransactionDate);
                result.Add(item.TransactionDate, sellRecordsAtDate);
            }
            else
            {
                result.Add(item.TransactionDate, new List<SellRecord> { item });
            }
        });
        return result;
    }
}