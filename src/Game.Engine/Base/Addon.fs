[<AutoOpen>]
module Game.Engine.Base.Addon

open Dap.Prelude

open Game.Engine

[<AbstractClass>]
type Addon (game : IGame) as _this =
    let kind = (_this.GetType ()).Name
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
        member __.Game = game
        member this.Update () = this.Update ()
        member this.Draw () = this.Draw ()
        member this.LateUpdate () = this.LateUpdate ()
        member this.LateDraw () = this.LateDraw ()
    interface ILogger with
        member __.Log evt = logger.Log evt