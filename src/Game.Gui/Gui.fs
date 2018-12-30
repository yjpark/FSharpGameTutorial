[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Gui

open System

open Game.Engine
open Game.Gui.Internal

open Dap.Prelude

[<Literal>]
let Kind = "Gui"

type IGui with
    member this.AddMenuItems ([<ParamArray>] items : MenuItem array) =
        this.Menu.AddItems items
        this

type IGui<'root when 'root :> Widget> with
    member this.AddChildren ([<ParamArray>] children : Widget array) =
        match this.Root0 with
        | :? Container as container ->
            container.AddChildren children
        | _ ->
            failWith "Not_Container" <| this.Root.GetType ()
        this

let create<'root when 'root :> Widget> (game : IGame) =
    let gui = new Gui<'root> (Kind, game)
    gui :> IGui<'root>
