# Hashmap

Arrays, including dynamic size array, provide quick access to the items stored in the array,
but searching in an array is a costly operation.

A data structure is needed which provides:

- quick read and write to elements in the array
- quick searching operations
- storing data in high volume without memory pressure

The solution is a HashMap where there is a set of keys, set of values and a map between them.
Key values are hashed in order to have a unique value pointing to the value stored.
This solution makes possible to have fast read and write access to the value.