[<AutoOpen>]
module Game.Engine.Base.Component

open Game.Engine

[<AbstractClass>]
type Component (entity : IEntity) =
    let mutable enabled : bool = true
    abstract member Update : unit -> unit
    abstract member Draw : unit -> unit

    default __.Update () = ()
    default __.Draw () = ()
    interface IComponent with
        member __.Entity = entity
        member __.Enabled
            with get () = enabled
            and set (a : bool) = enabled <- a
        member this.Update () =
            this.Update ()
        member this.Draw () =
            this.Draw ()
    member this.AsComponent = this :> IComponent
