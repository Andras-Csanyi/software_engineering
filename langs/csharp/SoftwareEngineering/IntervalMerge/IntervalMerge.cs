namespace AndrasCsanyi.SoftwareEngineering.IntervalMerge;

using Xunit.Abstractions;

public class IntervalMerge
{
    private readonly ITestOutputHelper _testOutputHelper;

    public IntervalMerge(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public List<Interval> MergeOverlappingIntervals(List<Interval> intervals)
    {
        List<Interval> result = new List<Interval>();

        if (!intervals.Any())
        {
            return result;
        }

        intervals.Sort((left, right) => left.Start.CompareTo(right.Start));

        foreach (Interval interval in intervals)
        {
            if (!result.Any())
            {
                result.Add(interval);
                continue;
            }

            Interval lastItemInTheResult = result.Last();
            if (lastItemInTheResult.End >= interval.Start)
            {
                result.RemoveAt(result.Count - 1);
                result.Add(new Interval
                {
                    Start = lastItemInTheResult.Start,
                    End = interval.End
                });
                continue;
            }

            result.Add(interval);
        }

        return result;
    }

    public List<Interval> MergeConsecutiveIntervals(List<Interval> intervals)
    {
        List<Interval> result = new List<Interval>();

        if (!intervals.Any())
        {
            return result;
        }

        intervals.Sort((left, right) => left.End.CompareTo(right.Start));

        foreach (Interval interval in intervals)
        {
            if (!result.Any())
            {
                result.Add(interval);
                continue;
            }

            Interval lastItemInTheList = result.Last();
            if (lastItemInTheList.End + 1 == interval.Start)
            {
                // removes last item
                result.RemoveAt(result.Count - 1);
                result.Add(new Interval
                {
                    Start = lastItemInTheList.Start,
                    End = interval.End
                });
            }
            else
            {
                result.Add(interval);
            }
        }

        return result;
    }
}