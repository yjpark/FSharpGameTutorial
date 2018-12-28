[<RequireQualifiedAccess>]
module Game.Engine.Game

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader

open Dap.Prelude
open Game.Engine.Internal

[<Literal>]
let ContentRoot = "Content"

let create (param : GameParam) : IGame =
    let game = new Game (param)
    game.Setup ()
    game.Run ()
    game :> IGame