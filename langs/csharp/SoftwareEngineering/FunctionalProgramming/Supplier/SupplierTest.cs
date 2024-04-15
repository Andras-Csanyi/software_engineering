namespace AndrasCsanyi.SoftwareEngineering.FunctionalProgramming.Supplier;

using Xunit;
using Xunit.Abstractions;

public class SupplierTest(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void NameTest()
    {
        IName name = new Name
        {
            FirstNameSupplier = () =>
            {
                // you can do a few things here
                return "Andras";
            },
            LastNameSupplier = () =>
            {
                // you can do things here
                return "Csanyi";
            }
        };

        testOutputHelper.WriteLine(name.PrintName());
    }
}