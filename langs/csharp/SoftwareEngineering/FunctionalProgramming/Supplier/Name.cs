namespace AndrasCsanyi.SoftwareEngineering.FunctionalProgramming.Supplier;

public class Name : IName
{
    public Func<string> FirstNameSupplier { get; set; }
    public Func<string> LastNameSupplier { get; set; }


    public string PrintName()
    {
        string name = $"{FirstNameSupplier()} {LastNameSupplier()}";
        return name;
    }
}