# Dynamic size array

In the article about arrays we concluded that arrays a good when you know under which index 
the element we are looking for.
Arrays in this case are fast (`O(1)`).
However, when the size management of arrays might be uncomfortable and error-prone.
Not to mention that the Api of lists aren't rich enough for daily work, there are things 
has to be implemented.
We want the software engineers to focus on the logic to be implemented and not arbitrary 
things like how the array size needs to be increased and how.
Dynamic size arrays provide solutions for these concerns.

Dynamic size arrays have many names across implementations.
In java they have the [ArrayList](https://github.com/openjdk/jdk/blob/master/src/javabase/share/classes/java/util/ArrayList.java) name, 
while in C# they are just [lists](https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs).

# Extra functionalities

Dynamic size array implementations might provide the following extras compared to arrays:

- safe array size management meaning the size of the array safely increased when it is needed
  and can be decreased on demand
- rich array operations Api

## Array size management

Increasing or decreasing the array size is no different in this case.
It is still an `O(N)` operation, but instead of actually implementing the size increase the 
implementation of array list hides it.
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
The [implementation](https://github.com/AdoptOpenJDK/openjdk-jdk11/blob/master/src/java.base/share/classes/java/util/ArrayList.java#L236) of array size increase is no different than we saw in the array article: 
the elements are copied to a new, increased size, array.

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