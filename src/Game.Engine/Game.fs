[<RequireQualifiedAccess>]
module Game.Engine.Game

open Dap.Prelude
open Game.Engine.Internal

[<Literal>]
let ContentRoot = "Content"

let create (param : GameParam) : IGame =
    let game = new Game (param)
    game.Setup (ContentRoot)
    game.Run ()
    game :> IGame