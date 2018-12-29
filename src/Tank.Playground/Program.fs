module Tank.Playground.Program

open System
open Argu

open Dap.Prelude

open Game.Engine
open Game.Gui

open Tank.Content
open Tank.Core

exception ParseException of string

type Args =
    | [<AltCommandLine("-v")>] Verbose
with
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Verbose -> "Print a lot of output to stdout."

let initialize =
    withAddon MainGui.create

let execute (args : ParseResults<Args>) =
    let consoleMinLevel =
        if args.Contains Verbose then
            LogLevelInformation
        else
            LogLevelWarning
    setupConsole consoleMinLevel |> ignore

    use _game = Game.tank initialize
    0 // return an integer exit code

[<STAThread>]
[<EntryPoint>]
let main argv =
    let parser = ArgumentParser.Create<Args>(programName = "Tank.Playground")
    try
        parser.ParseCommandLine argv
        |> execute
    with
    | ParseException m ->
        let usage = parser.PrintUsage()
        printfn "ERROR: %s\n%s" m usage
        1
    | e ->
        printfn "ERROR: %s" e.Message
        2
