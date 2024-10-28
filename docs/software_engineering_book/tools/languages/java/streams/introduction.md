---
title: Introduction to Java Stream
---

# Operations

## Intermediate operations

- can be chained
- return another stream

Position: in the chain of operations

Operations:

- `filter()`
- `map()`
- `flatMap()`
- `distinct()`
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
