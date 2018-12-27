module Tank.Playground.Program

open System

open Tank.Core

[<EntryPoint>]
let main argv =
    use game = Game.CreateAndRun ()
    0 // return an integer exit code
