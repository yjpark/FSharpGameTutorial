#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.Globbing.Operators

open Dap.Build

let allProjects =
    !! "src/Game.TexturePacker/*.csproj"
    ++ "src/Game.Engine/*.fsproj"
    ++ "src/Tank.Content/*.csproj"
    ++ "src/Tank.Core/*.fsproj"
    ++ "src/Tank.Playground/*.fsproj"

DotNet.create NuGet.debug allProjects

Target.runOrDefault DotNet.Build
