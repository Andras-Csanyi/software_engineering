---
title: Introduction to PotatoLang
---

> [!NOTE]
> This page is constantly changing

# Idea

After reading "Writing an interpreter in Go" and the "Writing a compiler in Go"
I decided to start working on my own programming language.
What can go wrong?
Right?

Both of the mentioned books are written by Thorsten Ball.
Both of the books help you to go through the "how on Earth this text will be
transformed to zeros and nulls so the computer can execute it" jungle in a safe
way.
No heavy books will fall on the toes.
It is safe.
And this exact experience with the topic makes me confident this journey will be
on one hand fun, and on the other very beneficial in learnings.

The goal is learning and gaining further experience in programming and possible
solutions.

# Goal and roadmap

Later in this article you'll find the specification of the language I am going
to work on.
Let me talk through the process I am going to follow.

First, I am going to create a lexer for the language using C#.
C# is the language I know the most and it is easy for me to prototype using it.
The other aspect its tooling support.
I can easily change between Rider and NeoVim and can be effective.

Secondly, I am going to create the compiler which will output bytecode for
Dotner CLR.
By this I'll increase further my Dotnet knowledge.
I assume that this is a safe territory and the CLR has good enough documentation
so with little research I can make progress.
This is my hope.

The third step will be creating a VM/Runtime instead of using CLR.

The fourth step is rewriting the whole in Zig.
Ok, why Zig?
I don't know.
Zig looks interesting while the constant drama around Rust feels problematic for
me.
Zig will give me the raw, close to machine experience I need.

# Spec

At first I'll start with what I saw in the books.
It will give me a comfortable start and some success.
As I move ahead I'll make decisions of what additional features I'd like to add
to the language.
Which is a great experience as I have to think through what I am going to do and
what impacts it might have.
An amazing thinking pattern to master.

## Types

At types there will be a little bit of mess up.
I don't like dynamically typed languages, so I am not going to create one.
According to the books a dynamically typed one is easier than a statically
typed, but fuck it... I do whatever the fuck I want to do.

On the other hand, the types I am going to create has their own pairs in `C#`,
so I am not going to create any magic.
But, what is the `Integer` in Potato, it is the `int` in `C#`.
From this point of view using Java would be more beneficial, but java is job and
not love.
This might cause some issues later, but I don't see these now.

Potato is going to have the following types:

- `Integer`, with the capital `I`, is an `Integer` object and corresponds to `C#`'s
  `Int32` type which is the primitive integer `int`.
- `String`, with the capital `S`, is a `String` object and corresponds to `C#`'s
  primitive `string` type.
- `Boolean`, with the capital `B`, it is a `Boolean` object and corresponds to
  `C#`'s `bool` type.

## Assignment

Examples are below:

```csharp
String stringIdentifier = "something string";
Integer integerIdentifier = 123;
Boolean booleanIdentifier = true;
```
