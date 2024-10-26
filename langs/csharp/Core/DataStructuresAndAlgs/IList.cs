namespace AndrasCsanyi.DataStructuresAndAlgs;

/// <summary>
///     Dynamic size array, short name, List.
///     The array is typed meaning it can handle only a single type.
///     The list is based on an array meaning this type in contiguous. The size of this list is dynamically managed and
///     doesn't require any act from the user.
/// </summary>
/// <typeparam name="T">The type of the items in the list.</typeparam>
public interface IList<T>
{
    /// <summary>
    ///     Adds a type T elem to the list. The place of the item is after the last item in the list.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <returns>Returns the list having the added element.</returns>
    T Add(T item);
}