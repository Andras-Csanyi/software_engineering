---
title: Java's AtomicInteger and AtomicReference
description: Java's AtomicInteger and AtomicReference types
---

# Background

During the last week I was working on my team's GraphQL schema to serve certain data for
Android developers for a new feature we are going to release sometime in the future.
The task included implementing a certain logic already exist in the frontend and bringing it
back to the backend and being to some extent a Backend-for-Fronted for the Android folks.
One of the logic included calculating average values.
Since I was mentally off due to other reasons (there was another really serious and escalated
issue I dealt with and it fucked up my brain royally... this is a different story for another
day) I just blindly implemented the logic I saw in the frontend code (typescript).
My plan was to have a code with tests and after shaping it in java correctly.

My mental state at the end of the week is described perfectly by the following tweet.

![My mental state](media/twitter.png)

# Story

The functionality looks like this.
There is a list of objects where a single object contains a number.
These numbers need to be summed and some other calculation has to be done to them.
I did the sum using the approach below.
The point is declaring an `Integer` and update it in the loop.
This does not compile as the compiler expects the updated integer in the loop to be `final` or
effectively final.

[!code-java[](src/demo/src/test/java/com/example/demo/Logic.java#L8-L18)]

IntelliJ instantly offers converting the `Integer` to `AtomicInteger`.
This is what I did and the code did not change a lot as you can see.
The code below compiles and does the job.

[!code-java[](src/demo/src/test/java/com/example/demo/Logic.java#L20-L30)]

But, there is a problem with this code.
The fact that there is an `AtomicInteger` there it suggest there is some multithreading here.
In my case there is no multithreading at that part of the code.
So, this is kind of misleading because it shows some intention in that direction.
At first, I thought when lambda is executed it does some virtual threads magic, but I haven't
found any proof for this.

Anyway, my colleague asked instantly why I use `AtomicInteger` there.
The fact that he asked this during review shows that the multithreading notion is strong, on
the other hand the codebase we have has multithreading at a few places, so the team is
receptive when it comes to multithreading.

The whole just didn't feel right.
The code just works fine with `AtomicInteger`, but the fact that the review is not smooth and
seemingly successfully disturbs the flow of the team makes the whole situation strange.
I started reading about this topic and turned out I did a sloppy job.
There is a way to solve this problem without `AtomicInteger` and this is the point where the
code should be massaged into the java way of solving this problem.

As you can see in the previous two code snippet the task is solved in a very generic and
imperative way.
The described logic can be easily implemented using any C like language.

The final solution is using java streams to sum the values from the input list and using that
value.
The snippet below shows this solution.

[!code-java[](src/demo/src/test/java/com/example/demo/Logic.java#L32-L42)]

# Lessons learned

For me the lesson is that I need to further enhance my skills and abilities to transform the
real world problems to java specific solutions instead of being satisfied with an average
solution.
The second lesson is that sometimes worth to put the problem aside and let the brain work.

# Links

- [Are java primitive ints atomic by design or by accident - Stackoverflow]("https://stackoverflow.com/questions/1006655/are-java-primitive-ints-atomic-by-design-or-by-accident)
- [AtomicInteger & lambda expressions in single-threaded app - Stackoverflow]("https://stackoverflow.com/questions/71488501/atomicinteger-lambda-expressions-in-single-threaded-app")
