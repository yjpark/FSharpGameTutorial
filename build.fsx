#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.Globbing.Operators

open Dap.Build

module NuGet = Dap.Build.NuGet

let feed =
    NuGet.Feed.Create (
        apiKey = NuGet.Environment "API_KEY_nuget_org"
    )

let libProjects =

    !! "src/Game.TexturePacker/*.csproj"
    ++ "src/Game.Engine/*.fsproj"
    ++ "src/Game.Gui/*.fsproj"

let allProjects =
    libProjects
    ++ "src/Tank.Content/*.csproj"
    ++ "src/Tank.Core/*.fsproj"
    ++ "src/Tank.Sandbox/*.fsproj"

//let options = NuGet.mixed libProjects
let options = NuGet.release

DotNet.create options allProjects

NuGet.extend options feed libProjects

Target.runOrDefault DotNet.Build
