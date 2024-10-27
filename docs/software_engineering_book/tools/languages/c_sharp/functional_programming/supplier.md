# Supplier

[!INCLUDE [supplier.md](../../../programming_paradigms/functional/supplier.md)]

In Dotnet there is no such thing as supplier interface like there is in java.
Dotnet uses [`Func<TResult>`](https://learn.microsoft.com/en-us/dotnet/api/system.func-1?view=net-8.0)
([source](https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Function.cs))
delegate type for this purpose.

## Where it is used

## Fun

In the example below there is a silly name creator where the first name and the last name
suppliers are `Func<TResult>` delegates.
The delegates are invoked in the `Print` method.

The interface where the properties are `Func<TResult>` delegate types.

The implementation of the `IName` interface.

A test where the `IName` is instantiated and executed.
