[<AutoOpen>]
module Game.Engine.Helper

open Dap.Prelude

type IEntity with
    member this.GetChild (key : string) : IEntity =
        this.TryFindChild key
        |> Option.get
    member this.GetComponent<'comp when 'comp :> IComponent> () : 'comp =
        this.TryFindComponent<'comp> ()
        |> Option.get

type IGame with
    member this.GetAddon<'addon when 'addon :> IAddon> () : 'addon =
        this.TryFindAddon<'addon> ()
        |> Option.get
