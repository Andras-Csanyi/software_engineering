---
uid: JavaFunctionalProgrammingSupplierInterface
---

# Supplier functional interface

[!INCLUDE [supplier.md](../../../programming_paradigms/functional/supplier.md)]

## Source

The interface can be found [here](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/function/Supplier.java).

```java

@FunctionalInterface
public interface Supplier<T> {

    /**
     * Gets a result.
     *
     * @return a result
     */
    T get();
}
```

## Where it is used?

- JDK has type specific suppliers like below, however if you take a look at the source code
  you'll see that these type specific suppliers are not inherited from `Supplier<T>`,
  rather they have the same concept but the result type is specific instead of generic.
  - [long supplier](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/function/LongSupplier.java)
  - [boolean supplier](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/function/BooleanSupplier.java)
  - [double supplier](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/function/DoubleSupplier.java)
  - [int supplier](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/function/IntSupplier.java)
- Some of the [Collector](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/stream/Collectors.java) class methods expect `Supplier<T>` input:
  - `toCollection`
  - `boxSupplier`
  - `groupingBy`
  - `toMap` and so on.
  - there are implementations in the Collector class also using `Supplier<T>` interface.
- The [Stream](https://github.com/openjdk/jdk/blob/master/src/java.base/share/classes/java/util/stream/Stream.java) interface also have a few methods expecting `Supplier<T>` argument, like:
  - `generate`

## Fun

In the provided code we are going to add few suppliers to a class via its builders
and when it is built these suppliers will be executed and the result printed out.

The interface

The implementation

Test and usage
