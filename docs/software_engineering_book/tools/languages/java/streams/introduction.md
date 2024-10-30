---
title: Introduction to Java Stream
---

# Operations

## Anatomy of streams

```java
List<Integer> someList = Arrays.asList(1,2,3);

// making the list to a stream
someList.stream()
  .flatMap() // intermediate operation
  .map() // intermediate operation
  .toList() // terminal operation
```

## Intermediate operations

- can be chained
- returns another stream

Position: in the chain of operations

Operations:

- `filter()` -- applies a filter on a stream and returns another stream
- `map()` -- applies the given function on every element in a stream and returns the stream of
  elements
- `flatMap()` -- flattens nested lists and arrays
- `distinct()` -- to remove duplicates in a stream and returning a stream with the unique
  elements
- `sorted()`
- `peek()`
- `limit()`
- `skip()`

## Terminal operations

- cannot be chained
- usually returns a single value

Position: last in the chain of operations

Operations:

- `anyMatch()`
- `allMatch()`
- `noneMatch()`
- `collect()`
- `count()`
- `findAny()`
- `findFirst()`
- `forEach()`
- `min()`
- `max()`
- `reduce()`
- `toArray()`
- `toList()`
