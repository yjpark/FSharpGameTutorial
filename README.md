I've been working on game development for a few years now, making game is indeed quite fun, it shares much with other kind of software development, while it also has its uniqueness. Always wanted to write more on it, though not really have good idea about how to start.

I've been working with a couple of game engines, mostly Unity3D, IwGame on Marmalade, Cocos2D, Phaser, created some own frameworks, did experiment with a very simple game engine in Elm as well. Most of them were designed in a similar way, provide similar components and tools. As game developers, we usually don't need to dig much in the game engine itself, but we should have a rather clear understanding about its structure so we can work on it efficiently.

I've decided to write some tutorials on game development, a very basic one, in my mind, it's mostly for developers without much experiences with game development, but curious in it. I'll try to share some of my understandings with game development, explain core components of game engine.

![Screen Shot](https://github.com/yjpark/FSharpGameTutorial/raw/master/screenshots/posts/intro.png)

## A 2D Tank Game
Current plan is to create a simple 2D topdown tank game in this tutorial, which is easy to understand, and have enough potential complexity as a real game. Not sure about what will eventually be covered, but at least got following ideas that worth writing about

- Map system, the maps will be created with Tiled map editor https://www.mapeditor.org/
- GUI for game itself, and for development
- The tank will have different weapon system, the parameters can be changed by buffs
- Special abilities that can be added with pickable items on map
- Enemies can be either tanks or other units, which need basic AI system to act by themself
- A couple game mechanics to give player purpose, and hopefully fun.
- Common features for games, such as achievements, charts, tutorials...

If possible also really want to write about real-time network game development, so ideally this tank game will be multi-player !

## Why F# ?
To make it even more fun for the potential readers, I choose F# as the language for this tutorial, in my opinion, F# is very suitable for learning, it's quite clean and concise, and it support both functional paradigm and object oriented paradigm, also it's a part of DotNet ecosystem, and have full access to all C# libraries. Even if you won't write F# code in the project, learning it can make you a bette developer with C# or other languages.

I don't plan to write too much about F# itself, there are many good F# tutorials on the web, personally I learned mainly from these two sites

- https://fsharpforfunandprofit.com/
- https://fsharp.org/

If you have coding experience in most modern programming language, should not take much time to get familiar with F# syntax, don't need to be expert to follow this tutorial.

It's not very practical to take pure functional approach in games, since for better performance, most game engines rely on mutable data structures, it's still possible to do it in pure functional way, at least for smaller games, but here I'll just focus on more traditional object-oriented way, so the ideas in this tutorial can be easily used in most game engines.

## DotNet Core with MonoGame
I'll build the tutorial on DotNet Core, which is cross-platform, have a great toolchain.

I use Visual Studio Code as main IDE, it's really good, the Vim binding is good, after setup a few shortcuts and some configuration, I feel very comfortable with it. The F# support is quite nice, still have a few issues, though mainly nice to use.

- https://dotnet.microsoft.com/
- https://code.visualstudio.com/

I choose MonoGame as the low level platform, will create very simple engine on top of it, it's not officially on DotNet Core yet, but a nice developer (cra0zy) did create a core version and put on nuget, I'll use this package in my tutorial

- http://www.monogame.net/
- https://www.nuget.org/packages/MonoGame.Framework.DesktopGL.Core/

Was thinking about use Fable and Pixi to create HTML5 games, which will be very cool too, though that approach need to bring more dependencies, and might make the whole process a bit complex for new comers, so I end up with MonoGame.

## The Plan
I'll keep working on the prototype, in the meantime, will start writing the tutorial, will be organized by topics, certain branches will be created for each post, also all the contents will be put into the repository as wiki pages.

## Please Check Wiki for List of Finished and Planned Post
