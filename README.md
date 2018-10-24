# HotChai.Json
A lightweight JSON Streaming Object Reader/Writer for .NET written in C#.

## Why?
I couldn't find a simple C# JSON streaming reader/writer implementation and I didn't want to take a dependency on that very popular and very large library you all know that's chock full of fancy features I don't need, like using reflection to automagically bloat up your objects.

I had previously written a lightweight JSON reader/writer specialized for another project that only required a few changes to generalize, so here it is in case you find it useful for your own projects.

## A Safer JSON
This library is based on **ObjectReader** and **ObjectWriter** classes intended for a messaging protocol, which enforce the restriction that the top-level JSON object MUST be `object` (not `element` per the [JSON specification](http://json.org)).

## Alternatives
If you own both sides of the protocol (client and server), I suggest you take a look at my other project [Serialize.Net](https://github.com/hotchaipro/Serialize.Net), which supports a more space-efficient variation of JSON (member keys are integers instead of strings) as well as Bencode, XML, and my own [PBON](http://pbon.info) encoding (optimized for binary payloads).

## Documentation
The **[Serialize.Net Wiki](https://github.com/hotchaipro/serialize.net/wiki)** has examples of reading and writing objects with this API, which I won't duplicate here. Go check them out.

The only difference in this library is that the key values are strings as opposed to the more efficient (but not interoperable) integer keys in my Serialize.NET library.

## Building
I use this library as a Visual Studio shared project, and I recommend you do, too. Just add and reference **HotChai.Json.shproj** from your project.

Enjoy!

-David
