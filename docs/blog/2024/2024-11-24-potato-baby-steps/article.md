---
title: Potato - basic assignments
---

It's time for a small victory lap and justify my viewpoint by just listing what
I have learned so far doing this thing.

[!Potato](images/potato.gif)

The code for this article is [here](https://github.com/PotatoLang/Potato/pull/2).

I worked on the lexer and parser part of the language in the last a few days and
I wanted to achieve that the following assignments are working:

```csharp
String stringIdentifier = "something string";
Integer integerIdentifier = 123;
Boolean booleanIdentifier = true;
```

I don't care about code quality.
The code is just raw-dogged there and if it works, it is great.
Beside the working logic **the tests are the most important things**.
These will help me later to rewrite the code and making it better.
The code eventually will be functional.

# Lexer

The lexer can process whatever string (source code) it receives and either creates the
specific token for it or creates one called `identifier` token.

The most interesting part of the lexer at this point is to manage `" "` (space)
character (which is a delimiter alongside with `;`) and string variable value.
String variable value can be anything including space.
For this I identified to modes for reading the next character: `Default` and
`StringVariableValue`.
The latter is when the lexer doesn't check what is the character just adds it to
the builder.

# Parser

At this point it doesn't do a lot.
It checks the syntax of the assignments and creates an AST node.
The AST node doesn't have a final format yet.

But, I have tests and some structure how the parser side can be managed.

# Learnings

- a lexer is a "two pointer" problem, a really nice one.
- [Pratt parser](https://x.com/i/grok/share/bkpwbYMpnzqC95qrEreHHscZQ)
- [Visitor design pattern](https://x.com/i/grok/share/mJmQxTL8rNCYhLtjZ1mCZk3P9)
- [How does Noam Chomsky's research in linguistics relates to compilers?](https://x.com/i/grok/share/EX7aUCAeLshPyrKmdHFs9BLXS)
- [What are the BNF, EBNF and CFG (Context Free Grammar)](https://x.com/i/grok/share/tKKPLleX30vXWq5iUjr3leSsN)

# Books

- [Writing An Interpreter in Go and Writing A Compiler in Go by Thorsten Ball](https://thorstenball.com/books/)
- [Crafting Interpreters by Robert Nystrom](https://craftinginterpreters.com/)
