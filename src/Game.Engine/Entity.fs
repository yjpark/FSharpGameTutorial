[<RequireQualifiedAccess>]
module Game.Engine.Entity

open Dap.Prelude
open Game.Engine.Internal

let add (key : string) (game : IGame) =
    game.Root.AddChild key |> ignore
    game
