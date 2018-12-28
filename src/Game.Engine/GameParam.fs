[<AutoOpen>]
module Game.Engine.GameParam

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open Dap.Prelude

let withExitKey (key : Keys) (param : GameParam) : GameParam =
    {param with ExitKey = Some key}

let withAddon (create : IGame -> 'addon) (param : GameParam) : GameParam =
    let create' = fun (game : IGame) ->
        create game :> IAddon
    {param with Initializers = param.Initializers @ [fun game -> game.Register create']}