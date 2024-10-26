# Dynamic size array

In the article about arrays we concluded that arrays provide fast access (`O(1)`) to elements
in the array.
However, when the size management of arrays might be uncomfortable and error-prone.
Not to mention that the api of arrays aren't rich enough for daily work, there are things
has to be implemented.
We want the software engineers to focus on the logic to be implemented and not arbitrary
things like how the array size needs to be increased and how.
Dynamic size arrays provide solutions for these concerns.

Dynamic size arrays have many names across implementations.
In java they have the [ArrayList](https://github.com/openjdk/jdk/blob/master/src/javabase/share/classes/java/util/ArrayList.java) name,
while in C# they are just [lists](https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs).

## Array size management

Increasing or decreasing the array size is no different in this case.
It is still an `O(N)` operation, but instead of actually implementing the size increase the
implementation of array list keeps it hidden.
By default, the array is initialised with a size and as the array size grows the
implementation decides if it is time to increase the size or not.
If it is time to increase the size then the array size will be increased by a pre-defined
value.

As you can see, as we are adding further and further elements to the array list we have the
`O(1)` operation and occasionally there is a `O(N)` operation.
The benefits of not dealing with size management and avoid the possible problems coming
from it is way higher than the occasionally linear time and space complexity.

For example, the C# implementation of the array list starts with an array size [4](https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs,38) and when
it is needed [doubles](https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs,405) the size of the array.

In case of java the default array size is [10](https://github.com/AdoptOpenJDK/openjdk-jdk11/blob/master/src/java.base/share/classes/java/util/ArrayList.java#L116) and the capacity of the array is increased by
[50%](https://github.com/AdoptOpenJDK/openjdk-jdk11/blob/master/src/java.base/share/classes/java/util/ArrayList.java#L254).
The [implementation](https://github.com/AdoptOpenJDK/openjdk-jdk11/blob/master/src/java.base/share/classes/java/util/ArrayList.java#L236) of array size increase is no different than we saw in the array article: the elements are copied to a new, increased size, array.

The benefits are that these methods are provided by the language maintainers and these functionalities
are widely tested and representing industry standards.

## Rich Api

Arrays don't exist in isolation.
We put data into them to use it later, and we want the list of items later sorted, filtered
or whatever is required by the implementation we are working on.
If we are using arrays we need to implement these functionalities always or, eventually, we
will have our own set of helper methods doing the job for us.
The problem with these local implementations or homebrew utilities is that they are
error-prone, they aren't tested heavily functionally and non-functionally.
They represent possible source of bugs.

Language developers provide these average utilities as part of the array list api.
These methods are tested heavily functionally and non-functionally and since they might be
open sourced, everyone can take a look at them and find bugs, and provide fixes.

The java array list api is available [here](https://github.com/AdoptOpenJDK/openjdk-jdk11/blob/master/src/java.base/share/classes/java/util/ArrayList.java#L236) while the C# is [here](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0).

# Operations and their complexities in a single-thread environment

| Operation                | Time Complexity            | Space complexity           |
| ------------------------ | -------------------------- | -------------------------- |
| [Add/Append](#addappend) | `O(1)` occasionally `O(N)` | `O(1)` occasionally `O(N)` |
| [Insert](#insert)        | `O(N)`                     | `O(N)`                     |
| [Overwrite](#overwrite)  | `O(1)`                     | `O(1)`                     |
| [Remove](#remove)        | `O(N)`                     | `O(N)`                     |
| [Delete](#delete)        | `O(1)`                     | `O(1)`                     |
| [Search](#search)        | `O(N)`                     | `O(1)`                     |

When it comes to dynamic size arrays worth to thinking in `already used part` and
in a `not used yet` part.
The sum of the two shows how big array is allocated.

Please note that the operations we are going to detail in the following sections are not
necessarily implemented.

## Add/append

The add operation is about adding a new element as last one to the existing array.
Since the implementation tracks what index is the next `not used yet` element
and the allocated array is guaranteed bigger or equal size to the `already used` side
there is no need for resize operation.
It means the operation is `O(1)` because this operation became to be an [overwrite](#overwrite)
in this case where the **time and space complexity** is `O(1)`.
When the `already used` size reaches the sum of `already used` and `not used yet` the
implementation will increase the size of the internal array.
This operation happens occasionally with `O(N)` **time and space** complexity.

## Insert

Insert operation is no different from [inserting and element into the array](array.md#insert).
It includes taking the elements following the index and shifting them right by one.
If the index to where the new item should be inserted is more than the actual max index value
(representing the allocated internal array size) the implementation will increase the size
of the internal array accordingly.

The **time and space complexity** of the operation is `O(N)`.

## Overwrite

The overwrite operation is no different from the array's [overwrite](array.md#overwrite)
operation.

The **space and time complexity** of the operation is `O(1)`.

## Remove

The remove operation is the opposite of the insert and no different from the array [remove](array.md#remove)
operation.
The operation includes removing the element from the array and shifting all elements following
it to left by one.

The **space and time complexity** of the operation is `O(N)`.

## Delete

The delete operation is no different from the array [delete](array.md#delete) operation.
It is about to set the value to default value at the designated index.

The **space and time complexity** of the operation is `O(1)`.

## Search

Search operation is no different from array [search](array.md#searching-for-an-element)
operation.

The **space complexity** of this operation is `O(1)`.
The **time complexity** of the operation is `O(N)`.
If other search method used than just scanning through the array the complexity values will
be different.
