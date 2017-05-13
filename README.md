Monads for .NET
===============

[![Build Status](https://travis-ci.org/rolspace/monads.net.svg?branch=master)](https://travis-ci.org/rolspace/monads.net)

*(This version of the original [repository](https://github.com/sergeyzwezdin/monads.net) has been modified to support .NET Standard 1.6)*

**Monads for .NET** is helpers for C# which makes easier every day of your developer life. Now supports .NET Standard 1.6.

In functional programming, a monad is a programming structure that represents computations. Monads are a kind of abstract data type constructor that encapsulate program logic instead of data in the domain model. A defined monad allows the programmer to chain actions together to build a pipeline to process data in various steps, in which each action is decorated with additional processing rules provided by the monad. Programs written in functional style can make use of monads to structure procedures that include sequenced operations, or to define some arbitrary control flows (like handling concurrency, continuations, side effects such as input/output, or exceptions).

More information about monads at <a href="http://en.wikipedia.org/wiki/Monad_(functional_programming)">Wikipedia</a>.

***

## Supported platforms

.NET Standard 1.6

## Installing

Just reference **"Monads.dll"** file and add **"using System.Monads;"** to your code.

## Contribution

I'm glad to see your contributions for Monads.NET.
Just fork the project and pull request when you're ready.

## License
Released under the [MIT license](http://www.opensource.org/licenses/MIT).

## Benefits (code samples)

Before
<pre>string workPhoneCode;

if (person != null)
{
  if (person.Work != null)
  {
    if (person.Work.Phone != null)
    {
       workPhoneCode = person.Work.Phone.Code;
    }
  }
}</pre>

After
<pre>string workPhoneCode = person.With(p=>p.Work).With(w=>w.Phone).With(p=>p.Code);</pre>

---

More info at [wiki](https://github.com/sergun/monads.net/wiki):

1. [Monads for objects](https://github.com/sergun/monads.net/wiki/Monads-for-objects)
2. [Monads for collections](https://github.com/sergun/monads.net/wiki/Monads-for-collections)
3. [Argument checking](https://github.com/sergun/monads.net/wiki/Argument-checking)
4. [Events](https://github.com/sergun/monads.net/wiki/Events)