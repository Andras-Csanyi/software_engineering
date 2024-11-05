---
title: Add method
description: Add method of the dynamically sized array
---

The first thing to be implemented is the `Add` method.

# The Interface

The following snippet shows the result interface of creating the `Add` method and some
arbitrary methods for better testing.
The relevant merge request is [this](https://github.com/Andras-Csanyi/software_engineering/pull/48) one.

```csharp
namespace AndrasCsanyi.DataStructuresAndAlgs.DynamicSizeArray;

/// <summary>
///     Dynamic size array, short name, List.
///     The array is typed meaning it can handle only a single type.
///     The list is based on an array meaning this type in contiguous. The size of this list is dynamically managed and
///     doesn't require any act from the user.
/// </summary>
/// <typeparam name="T">The type of the items in the list.</typeparam>
public interface IDynamicSizeArray<T>
{
    // add method snippet start

    /// <summary>
    ///     Adds a type T elem to the list. The place of the item is after the last item in the list.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    void Add(T item);

    /// <summary>
    ///     Returns the elements at the defined index value.
    /// </summary>
    /// <param name="index">The index value.</param>
    /// <returns>Element of {T}.</returns>
    T Get(int index);

    // add method snippet end

    /// <summary>
    ///     Returns the amount of elements in the Dynamic Size Array. The amount of elements does not equal to the allocated
    ///     size of the storage array of the implementation. For that <see cref="DynamicSizeArray{T}.StorageSize()" />
    ///     test method.
    /// </summary>
    /// <returns>The amount of elements in the Dynamic Size Array.</returns>
    int Count();
}
```

First we need the previously mentioned `Add` method which returns `void` when it is called.
As I mentioned previously nothing fancy here just the bare functionality and when needed we
will add further interfaces and comfort things like you can find in what Dotnet team provides.

The `Get` method is needed for testing and to have access to a particular index in the
underlying array.

The `Count` method provides the information about how many elements are in the list.
As the documentation says it is not the allocated size of the underlying array.

# The Implementation

At this moment two files, both included below, contains the implementation.
The testmethods one includes methods let us to take a look under the hood and test the inner
workings of the implementation too. These methods should be stripped if this code would be a
production code.

## Initialization

When a `DynamicSizeArray` is initialized by `DynamicSizeArray<int> a = new();` the following happens:

- a new typed array will be created and its default size is `8`. Why 8? Because I like this
  number. We don't have information about with how big arrays our users, they don't exist, are
  working so we just need a number.
- the default size of the storage (the underlying array) is also will be set up. This number is
  needed when the array size will be increased and it is an implementation details our users
  should not know.
- at this point the array is empty, meaning `0` elements are in it, the
  `_amountOfElementsInTheStorage` is default 0.

At this point worth to take a look at the `Defaults.cs` test file where the default values are
tested.
The explanation for the tests are at the bottom of this page.

## Adding an element

When at element is added to the array two scenario can happen:

- the size of the underlying array provides enough space and the item can be added
- the size of the underlying array is not enough so its size needs to be increased

The whole logic is based on knowing how many elements are in the `_storage`, this one has to be
tracked manually, and how big the allocated size of the array, this information is there and
can be accessed at any time. The `_amountOfElementsInTheStorage` is basically a pointer to the
last not default value item in the `_storage` array.

In the case of when the size of `_storage` doesn't have to be changed the logic is pretty
straightforward. First the new item should be added after the last item item in the array. The
`_amountOfElementsInTheStorage` pointer plays a dual role here. Its value tells us how many
elements are in the array like 1, 2 or 3, it also tells us the next available place in the
array due to the zero indexing nature of the whole shebang. It means that when we have an item
on the index `0` it means we have `1` item in the array and that the slot under the `1` is
available.

The other scenario is when array size management is needed. The first step here
is creating a new array with the increased size. The default strategy is
doubling the size of the previous array. At this point we need the
`_storageAllocatedSize` to know what is the size we are looking for. The next
step is copying all items from the old `_storage` to the new one. Here we have
to pay attention to that the index values must be the same. However, just simply
iterating through the array is fine. The next step is setting the variable
values controlling the inner workings of the `DynamicSizeArray` like
`_amountOfElementsInTheStorage`, `_storageAllocatedSize` and overwriting the old
`_storage` variable with the new one. At this point the `DynamicSizeArray`
increased its size and behaves like nothing happened.

`DynamicSizeArray.cs` file

```csharp
namespace AndrasCsanyi.DataStructuresAndAlgs.DynamicSizeArray;

public partial class DynamicSizeArray<T> : IDynamicSizeArray<T>
{
    private readonly int _storageDefaultSize = 8;
    private int _amountOfElementsInTheStorage;
    private T[] _storage;
    private int _storageAllocatedSize;

    public DynamicSizeArray()
    {
        _storage = new T[_storageDefaultSize];
        _storageAllocatedSize = _storageDefaultSize;
    }

    public void Add(T item)
    {
        if (_amountOfElementsInTheStorage == _storageAllocatedSize)
        {
            T[] newStorage = CreateIncreasedStorageWithContent(_storage);
            _amountOfElementsInTheStorage = _storageAllocatedSize + 1;
            _storageAllocatedSize = newStorage.Length;
            _storage = newStorage;
            return;
        }

        _storage[_amountOfElementsInTheStorage] = item;
        _amountOfElementsInTheStorage++;
    }

    public T Get(int index)
    {
        if (index > _amountOfElementsInTheStorage - 1)
        {
            throw new ArgumentOutOfRangeException(
                $"There is no item at the {index} in this array."
            );
        }

        return _storage[index];
    }

    public int Count() => _amountOfElementsInTheStorage;

    private T[] CreateIncreasedStorageWithContent(T[] storage)
    {
        T[] newStorage = new T[_storageAllocatedSize * 2];
        for (int i = 0; i < storage.Length; i++)
        {
            newStorage[i] = _storage[i];
        }

        return newStorage;
    }
}
```

`DynamicSizeArray.TestMethods.cs` file.

```csharp
namespace AndrasCsanyi.DataStructuresAndAlgs.DynamicSizeArray;

public partial class DynamicSizeArray<T>
{
    public int StorageSize()
    {
        return _storage.Length;
    }

    public int StorageDefaultSize()
    {
        return _storageDefaultSize;
    }
}

```

## Get method

In order to make the `DynamicSizeArray` easy to test I added the `Get(int
index)` method. It returns the element under the provided index value.
The input is validated in order to throw a controlled exception and not either
returning the given `T` type `default` value or `IndexOutOfBoundException`. For
the users this `DynamicSizeArray` is not bigger then all the items they put into
it. They don't have to know about that the array is actually bigger.

# Tests

## Defaults

The code below tests if the `DynamicSizeArray` underlying array got created with
the correct allocation size. The default size is an implementation detail, but
made available for testing purposes.

```csharp
    [Fact]
    public void DefaultStorageSize()
    {
        DynamicSizeArray<int> dsa = new();
        dsa.StorageSize().Should().Be(dsa.StorageDefaultSize());
    }
```

The following test checks if the volume of elements in the array (what the user
put into it) is zero right after instantiation.

```csharp
    [Fact]
    public void DefaultElemSize()
    {
        DynamicSizeArray<int> dsa = new();
        dsa.Count().Should().Be(0);
    }
```

## Add method

The following test checks what happens when an element is added to the array,
but it doesn't trigger size management. Once the element is added the `Count()`
and `StorageSize()` values are checked if the expected behaviour is there.
The `for` loop is for checking if the element indeed in the array.

```csharp
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
```

The test below tests the scenario where a size management event happens. First,
a new `DynamicSizeArray` is created and it is filled up with elements to the
point when size management is not triggered yet. The inner workings are checked
at this point. As a next step and new item is added and right after the
`StorageSize` (this has to be doubled compared to the previous one) and
`Count()` checked. The `Count()` value must show that a new item has been added
to the array, so its value got increased by one.

## Get method

The following test is a quite simple one. The functionality of adding an element
and getting it back is checked.

```csharp
    [Fact]
    public void ReturnItem()
    {
        int testValue = 11;
        DynamicSizeArray<int> su = new();
        su.Add(testValue);

        su.Get(0).Should().Be(testValue);
    }
```

The following test is about testing the validation of the `Get` method. If the
requested index is higher than the elements in the array an exception will be
thrown.

```csharp
    [Fact]
    public void Throw_WhenIndexOutOfRange()
    {
        DynamicSizeArray<int> su = new();
        su.Add(11);

        su.Get(0).Should().Be(11);

        Action action = () => su.Get(1);
        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
```
