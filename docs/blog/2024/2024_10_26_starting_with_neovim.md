---
title: Starting with NeoVim
description: An overview of NeoVim whats and whys before you jump into it.
---

# Introduction

The assumption of this article is that you are not really familiar with [NeoVim](https://neovim.io), but for some
reason feel the itch to try it out and kind of to some extent understanding what is this hype
around it.
I also assume that you have some experience with IDEs like Visual Studio, VS Code or any
[JetBrains](https://jetbrains.com) products and you have some understanding what these tools can give you.

If the reality is highly different from the assumptions above this article might not for you.
Just managing expectations.

# NeoVim

When it comes to [NeoVim](https://neovim.io) worth to make the following separation of services you can get from the
editor.
The separation is needed in order to what questions to ask and understanding what is
related to what.

## Vim motions

This is the magic of Vim and not just [NeoVim](https://neovim.io).
Vim motions help you to navigate quickly and effectively in a document and still effectively
making changes in it.
One source of the efficacy is the fact that you don't have to move your hands between the
keyboard and the mouse.
It spares a lot of time and effort.

In my opinion vim motions based on touch typing.
I don't really know what efficiency increase can be achieved without touch typing.
Before I stepped into the [NeoVim](https://neovim.io) world I spent months with learning touch typing.

You don't need to use [NeoVim](https://neovim.io) or Vim to get this efficacy advantage.
The mentioned editors can work with Vim motions after installing the proper plugins.
I use IntelliJ and Rider with IdeaVim plugin and it works just fine.
But, the main difference between [NeoVim](https://neovim.io) and IdeaVim is that [NeoVim](https://neovim.io) can be configured to do
overall editor related things like window management and so on with certain keys
while IdeaVim has limitations in this aspect.
I asked a few times the devs and the answer was that IdeaVim is a document editing related
plugin and it has nothing to do what the whole editor can do.
For these you have to use the magic provided by [JetBrains](https://jetbrains.com).
But, again, this is not document editing scope, it is editor scope.
This is an important expectation management point.

## Code completion

When you open your favourite editor, mine is any [JetBrains](https://jetbrains.com) product, you'll get instantly code
completion.
It is many times mentioned as IntelliSense.
You don't know where the information displayed in the code completion window is sourced and why
it is in that order and so on.
When it comes to [NeoVim](https://neovim.io) this is something you have to configure and you have very fine gained
control over it.
The code completion can work anywhere in [NeoVim](https://neovim.io) while in other editors the scope of code
completion can be limited.

Many times it feels the fine-gained nature of configurability is just a huge pain in the ass.

The module for this is CMP and additional plugins provide the content.
You have to figure out what is the order of the content in the displayed window.
For example:

- Language Server will provide a lot of content in the code completion window
- Snippet engines
- Language specific modules
- File system related information for example path related info
- Tooling related things like git

It is possible to configure even that how the possible completion text parts are displayed.
For example it can be a shadow text or no shadow text.
Another option is how the TAB key works and so on.

## Snippets

These are simple or smart (you can go through the template by the TAB key - it is called as
supertab) templates.
In [NeoVim](https://neovim.io) world these are separate projects and added as plugins and maintained by the
community.
In, for example, [JetBrains](https://jetbrains.com) world you can create your own templates and somehow you can
distribute them between your instances.
Smart template in [JetBrains](https://jetbrains.com) world for example `sout` which creates the `System.out.println()`
line in the code.

## [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) - Language Server Protocol

When you start you IDE and work on your code you highly probably not aware of that what [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) is
used and even why.
In your code completion window the information provided by the [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) behind the scene is just
displayed.

[LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) is a service, it mainly runs as a separate service in the background, providing the
following services for you:

- continuously compiling the code you write and providing the feedback, but how this
  information is displayed depends on the editor. Yes, you guessed right it is configurable in
  [NeoVim](https://neovim.io),
- continuous analysis, for example Roslyn in Dotnet world, and providing feedback, but how it
  is displayed depends on the editor. Yes, you guessed right it is configurable in [NeoVim](https://neovim.io),
- location dependent code completion. When you press Ctrl/Cmd-n in any [JetBrains](https://jetbrains.com) editor it
  offers a list what stuff can be done like adding a constructor or overwriting base methods and
  so on. This information is context dependent and the [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) is the animal understanding this
  context. The editor in this case just sending the information to the [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) and it does its magic.
- navigation through the whole solution. You might came across the "Go To Definition" or "Go to
  implementation" functionalities. These are leveraging on the [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) capabilities.
- Formatting the code

Probably the list above is not full.

The main thing with [NeoVim](https://neovim.io) is that it offers quiet easy integration with [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol)s and this makes
[NeoVim](https://neovim.io) superawesome because you can hack the shit out of both the [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) and [NeoVim](https://neovim.io).
This hacking is the source of innovation.

## DAP - Debug Adapter Protocol

The editor you use probably has a decent debug capability.
[NeoVim](https://neovim.io) can be armed with these capabilities too and the base is the [DAP](https://microsoft.github.io/debug-adapter-protocol/) protocol.
All debugging related things you see related to [NeoVim](https://neovim.io) is built on [DAP](https://microsoft.github.io/debug-adapter-protocol/).

The situation here is the same as it is with the [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol).
All the things coming back from [DAP](https://microsoft.github.io/debug-adapter-protocol/) can be displayed in the editor and it is configurable.

## Formatters

Code formatting is another something which is not really and fully separated in editors like
[JetBrains](https://jetbrains.com).
At least it took a while for me to see what a formatter is, what an [LSP](https://en.wikipedia.org/wiki/Language_Server_Protocol) is and how they relate
to code formatting.
There are services and tools (prettier is a good example) focusing only formatting the code.
They don't provide any other thing just going through the code and format.

What formatter should be used is configurable in [NeoVim](https://neovim.io).

## Plugins

And there are many other packages giving you all the magic, and configurability hell, you want.

# Summary

These are the big topics I could identify so far.
I believe if you know these you can focus your effort easier and probably the frustration risk
is way lower and the success risk is higher.
Personally, I tried to configure my own [NeoVim](https://neovim.io), but failed and it is normal.
I started eventually using [LazyVim](https://lazyvim.org) and with small configuration it fits for my needs.
The documentation of [LazyVim](https://lazyvim.org) is extremely good and [Folke](https://github.com/folke) is the mastermind behind it.
The community is active and you can learn a lot just reading the Discussions section of the
project.

At this stage [NeoVim](https://neovim.io) is not really suitable for daily usage in Java and Dotnet environments in
my opinion.
There will be another ranting post about why...
But, the progress is tremendous and there is still hope.

But, investing in [NeoVim](https://neovim.io) worth every second especially the touch typing and vim motions part.
If you put your toes into the other topics you'll learn a lot and learning is always good.

# Further materials

- [All vim related rants from ThePrimeAgen](https://www.youtube.com/@ThePrimeagen)
- [He has a Vim dedicated channel](https://www.youtube.com/@TheVimeagen)
- [Neovim from scratch by chris@machine - the mastermind behind LunarVim](https://www.youtube.com/watch?v=ctH-a-1eUME&list=PLhoH5vyxr6Qq41NFL4GvhFp-WLd5xzIzZ)
