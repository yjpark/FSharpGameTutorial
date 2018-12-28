[<AutoOpen>]
module Game.Engine.BaseAddon

open Dap.Prelude

[<AbstractClass>]
type BaseAddon (kind : string, game : IGame) =
    let logger : ILogger = getLogger <| sprintf "%s:%s" game.Param.Name kind

    abstract member Update : unit -> unit
    abstract member Draw : unit -> unit
    abstract member LateUpdate : unit -> unit
    abstract member LateDraw : unit -> unit

    default __.Update () = ()
    default __.Draw () = ()
    default __.LateUpdate () = ()
    default __.LateDraw () = ()

    interface IAddon with
        member __.Kind = kind
        member __.Game = game
        member this.Update () = this.Update ()
        member this.Draw () = this.Draw ()
        member this.LateUpdate () = this.LateUpdate ()
        member this.LateDraw () = this.LateDraw ()
    interface ILogger with
        member __.Log evt = logger.Log evt