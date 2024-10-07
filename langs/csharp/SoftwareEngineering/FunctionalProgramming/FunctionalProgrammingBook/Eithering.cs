namespace AndrasCsanyi.SoftwareEngineering.FunctionalProgramming.FunctionalProgrammingBook;

using LanguageExt;
using Xunit;
using Xunit.Abstractions;

public class Eithering
{
    public Either<ErrorResult, List<ResultDto>> DoSomething()
    {
        return FetchTheShit()
            .MapTheShit()
            .RemoveSome();
    }

    public Either<ErrorResult, List<Result>> FetchTheShit()
    {
        return Either<ErrorResult, List<Result>>.Right(
        new List<Result>
        {
        new(1L, "name1"),
        new(2L, "name2"),
        new(3L, "name3"),
        new(4L, "name4"),
        });
        // return Either<ErrorResult, List<Result>>.Left(new ErrorResult("error at database"));
    }
}

public static class EitheringMethods
{
    public static Either<ErrorResult, List<ResultDto>> MapTheShit(
        this Either<ErrorResult, List<Result>> either)
    {
        return either.Match(
           Left: Either<ErrorResult, List<ResultDto>>.Left ,
           Right: (List<Result> result) =>
           {
               return Either<ErrorResult, List<ResultDto>>.Left(new ErrorResult("mapping issue"));
               List<ResultDto> r = result.Select(i => new ResultDto(i.id, i.name)).ToList();
               return Either<ErrorResult, List<ResultDto>>.Right(r);
           });
    }

    public static Either<ErrorResult, List<ResultDto>> RemoveSome(
        this Either<ErrorResult, List<ResultDto>> either)
    {
        return either.Match(
            Left: Either<ErrorResult, List<ResultDto>>.Left,
            Right: (List<ResultDto> result) =>
            {
                return result.Where(i => i.name != "name4").ToList();
            });
    }
}

public record ErrorResult(string error);

public record Result(long id, string name);

public record ResultDto(long id, string name);

public class EitheringTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public EitheringTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void test()
    {
        Eithering eithering = new();
        Either<ErrorResult, List<ResultDto>> result = eithering.DoSomething();

        result.IfRight(result =>
        {
            _testOutputHelper.WriteLine(result.Count.ToString());
            result.ForEach(i => { _testOutputHelper.WriteLine(i.ToString()); });
        });

        result.IfLeft(errorResult => { _testOutputHelper.WriteLine(errorResult.ToString()); });
    }
}