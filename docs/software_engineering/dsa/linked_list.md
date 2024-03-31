# Linked list

The contiguous nature of array has its drawbacks and needs to be mitigated.
The problem might arise from arrays contiguous nature is when the array size is big enough it
will force the computer to juggle around with items in its memory, or the computer will crash.
We need a solution which still provides similar services as array does.
The fairly good solution is Linked List.

## Time and space complexity

| Operation  | Time complexity | Space complexity |
|------------|-----------------|------------------|
| Insert     | O(1)            | O(1)             |
| Add/Append | O(1)            | O(1)             |
| Delete     | O(1)            | O(1)             |
| Search     | O(N)            | O(1)             |
| List       | O(N)            | O(1)             |

### Insert

### Add/Append

### Delete

### Search

### List

## Compared to array

| Operation  | Linked List Time complexity | Linked List Space complexity | Array Time Complexity | Array Space complexity |
|------------|-----------------------------|------------------------------|-----------------------|------------------------|
| Insert     | O(N)                        | O(1)                         | O(N)                  | O(1)                   |
| Add/Append | **O(1)**                    | O(1)                         | O(1)                  | O(1)                   |
| Delete     | **O(1)**                    | O(1)                         | O(N)                  | O(1)                   |
| Search     | O(N)                        | O(1)                         | O(N)                  | O(1)                   |
| List       | O(N)                        | O(1)                         | O(N)                  | O(1)                   |
| Get        | O(N)                        | O(1)                         | **O(1)**              | O(1)                   |

The Linked List provides better performance in many cases like Delete and Add/Append operations.
But the strength of an array is still that an element can be added constant time to any index in the array
and can be retrieved.
To achieve the same one has to have a reference to the previous or next element in a Linked List solution.
However,

> [!Note]
> Today memory is available, and we have plenty, so dealing with the contiguous nature of
> arrays might not seem necessary. The point of knowing time and space complexity is
> not swiping them away by that we have plenty of memory. The point is getting
> indication of how the software will work when it is scaled up.
