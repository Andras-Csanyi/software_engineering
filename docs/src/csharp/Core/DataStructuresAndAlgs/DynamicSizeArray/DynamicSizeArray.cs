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