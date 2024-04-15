namespace AndrasCsanyi.SoftwareEngineering.FunctionalProgramming.Supplier;

public interface IName
{
    string PrintName();
    Func<string> FirstNameSupplier { get; set; }
    Func<string> LastNameSupplier { get; set; }
}