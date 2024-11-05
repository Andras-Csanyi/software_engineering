---
title: Introduction
description: Some introduction to the implementation process
---

In this chapter we are going to implement a data structure providing the
capability of managing its own size. This way we can work comfortably with an
array like structure and not considering or concerning its actual size.

The implementation process will be fine grained and explanatory. Every page will
have the relevant merge request (MR) attached to it where the code changes can
be investigated. However, I am going to show the full code in the page.

During the implementation I am not looking at how the Dotnet team implemented
their `List<T>` because it would only disturb me and reduce the experience of
going through the whole process. I will add all the fancy things as we go and
when they are needed and not earlier.

The data structure is not production ready. Its purpose is for understanding and
learning.
