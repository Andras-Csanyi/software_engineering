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