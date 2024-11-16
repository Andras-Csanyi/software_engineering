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

    /// <summary>
    /// Removes the item at the designated index in the dynamically sized array.
    /// Every item after the designated item will be shifted left by 1, meaning their index will be reduces by one.
    /// </summary>
    /// <param name="index">The index to be removed.</param>
    void RemoveAt(int index);
}
