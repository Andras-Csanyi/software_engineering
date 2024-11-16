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

    public void RemoveAt(int index)
    {
        if (!ValidateIndexForRemoval(index))
        {
            throw new ArgumentException(
                    $"The provided index value: {index} is either higher than the items volume in the array, " +
                    "or a negative number"
                    );
        }
        // create a new storage with the same allocation size as the original one
        T[] newStorage = new T[_storageAllocatedSize];

        for (int i = 0; i <= _amountOfElementsInTheStorage; i++)
        {
            // here we control what happens before the provided index value is less
            // than the index managed by the for loop
            // the ifs below do not cover the case when the provided index equals
            // to the index managed by the for, this is how we skip that value.

            // before the index value in the original storage
            if (i < index)
            {
                newStorage[i] = _storage[i];
            }

            // after the index in the original storage
            // in the new storage the index value is reduced by 1
            if (i > index)
            {
                newStorage[i - 1] = _storage[i];
            }
        }
        // overwrite the old storage with the new one
        _storage = newStorage;
        // reduce the counter representing how many items we have in the array
        _amountOfElementsInTheStorage--;

    }

    private bool ValidateIndexForRemoval(int index)
    {
        if (index < 0 || index >= _amountOfElementsInTheStorage)
        {
            return false;
        }
        return true;
    }

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
