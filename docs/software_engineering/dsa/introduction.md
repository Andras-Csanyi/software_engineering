# Introduction

When it comes to operations on data structures we need to take a look at these from
multiple point of view like:

- what are the operations?
- how efficiently these operations can be executed with the particular operation?
- single-thread and multi-thread environments

In order to have a clear picture, be able to compare the data structures and eventually make
a sound decision why one is fit while the other one is not fit for the situation we need
to have clear definitions.

## Operations

### Add/Append

Describes an operation which adds a new element either as first or last item.

### Insert

Describes an operation where the fact that the new element become part of the data structure
cause that the elements behind the new element shifted.

### Overwrite

Describes an operation where the designated item (element of a list or array) is going to be
overwritten by the supplied item.

### Remove

Describes an operation which removes the item from a list of elements in a way
the previous and next items of the removed item will be neighbours

### Delete

Describes an operation where the element becomes `null`, but its place not removed
from the array.

### Search

Describes an operation where we are looking for an element based on some parameters.

## Efficiency

## Big O notations

The general rule of thumb with Big O notation is that we are considering only the worst case.
This is a practical solution and helps make fairly good decisions quickly.
However, there are cases when it makes sense to take a look at the average cases.
The more colorful picture might help make more fine-grained decisions.

## Identifying Big O types

## Single-thread vs Multi-thread environment