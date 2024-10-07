namespace AndrasCsanyi.SoftwareEngineering.FunctionalProgramming.FunctionalProgrammingBook.MethodChaining;

using Xunit;
using Xunit.Abstractions;

public class Practice
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Func<Person, string> emailFor = p => AppendDomain(AbbreviateName(p));

    public Practice(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void test()
    {
        Person joe = new("Joe", "Bloggs");
        string email = emailFor(joe);
        _testOutputHelper.WriteLine(email);
    }

    public static string AbbreviateName(Person p)
    {
        return Abbreviate(p.FirstName) + Abbreviate(p.LastName);
    }

    public static string AppendDomain(string localPart)
    {
        return $"{localPart}@whatever.com";
    }

    public static string Abbreviate(string s)
    {
        return s.Substring(0, Math.Min(2, s.Length)).ToLower();
    }
}

public record Person(string FirstName, string LastName);