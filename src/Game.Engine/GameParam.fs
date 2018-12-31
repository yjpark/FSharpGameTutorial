[<AutoOpen>]
module Game.Engine.GameParam

open Dap.Prelude

open Game.Engine.Addon

let withExitKey (key : Keys) (param : GameParam) : GameParam =
    {param with ExitKey = Some key}

let withSetup (setup : IGame -> unit) (param : GameParam) : GameParam =
    {param with Initializers = param.Initializers @ [setup]}

let withAddon (create : IGame -> 'addon) (param : GameParam) : GameParam =
    let create' = fun (game : IGame) ->
        create game :> IAddon
    {param with Initializers = param.Initializers @ [fun game -> game.Register create']}

let withMask (rect : Rectangle) (color : Color) =
    withAddon <| Mask.Create rect color