# Array

Array represents a contiguous space of the memory.
Which means that the elements of an array are placed next to each other.

An array is always fixed size, and its size has to be provided at initialization.
The values of the array are set to default (it depends on the language).

# Operations

| Operation | Big O notation    |
|-----------|-------------------|
| Add       | `O(1)` - constant |
| Insert    | `O(N)` - linear   |
| Search    | `O(N)` - linear   |
| Delete    | `O(1)` - constant |

## Adding and elements

In reality there is no such thing adding an element to an array.
The add operation overwrites the value at the designated place.

## Insert

The insert operation has 3 versions:

- insert as first element (and everything shifts right)
- insert somewhere in the middle (and everything right to it shifts right)
- insert as last element (nothing gets shifted)

Insert consists of two operations:

- take the values after the designated index and shift them left
- insert the value to the place

This operation has a problem due to that arrays are fixed size.
The `Insert` operation can cause data loss or unwanted exceptions.

The other problem comes with `Insert` is that shifting the original array elements requires
another array and by that increasing the space complexity.

## Searching for an element

Finding an element in an array means that the search has to go to all elements and check if it
is the searched one.
It means we have to iterate through the array.

## Delete an element

In reality there is no such thing to remove an element from an array.
The operation set the value at the designated index to default or `null`.

## Remove an element

The remove operation is similar to `Insert`. It also has 3 variations:

- Remove an element from the first place and shift left everything after the deleted element
- Remove an element from the middle and shift left everything after the element
- Remove an item from the last position, here there is no shift only adding default value

# C# implementation

# Java implementation