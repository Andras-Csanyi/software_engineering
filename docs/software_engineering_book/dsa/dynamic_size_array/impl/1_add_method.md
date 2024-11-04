---
title: Add method
description: Add method of the dynamically sized array
---

The first thing to be implemented is the `Add` method.

# The Interface

The following snippet shows the result interface of creating the `Add` method and some
arbitrary methods for better testing.
The relevant merge request is this one.

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

The other scenario is when array size management is needed.

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
