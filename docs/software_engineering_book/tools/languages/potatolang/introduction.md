---
title: Introduction to PotatoLang
---

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

# Goal

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

```csharp
var myIntegerLookingVariable = 3;

var myStringLookingVariable = "this is a string";

var myVariableFromExpression = 3 * (2 + 6);

var myIntegerArrayLookingStructure = [1, 2, 3];
var myValueFromArrayByIndex = myIntegerArrayLookingStructure[0]; // ==> 1

var myStringArrayLookingStructure = ["asd", "bsd", "csd" ];
var myValueFromStringArrayByIndex = myStringArrayLookingStructure[0]; // ==>
"asd"

var hashMapLookingStructure = { "name" : "Andras", "age": 40 };
var nameFromHashMap => hashMapLookingStructure[0]; // ==> "Andras"

var bindingFunction => function(string a, string b) {return a + b;};
bindingFunction(1, 2); // returns 3

// recursive call
var recursiveMethod => function(integer number) { recursiveMethod(value);}

// control structures
if(a > b)
{
  // whatever
}

for(var i = 0; i < len(stringArray); i++)
{
  // whatever
}
```
