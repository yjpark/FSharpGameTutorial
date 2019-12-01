[<AutoOpen>]
module Game.Gui.Internal.Gui

open System
open Myra
open Myra.Graphics2D.UI

open Game.Engine
open Game.Engine.Base
open Game.Gui

type internal Gui<'root when 'root :> Widget> (game : IGame) =
    inherit Addon (game)

    do (
        MyraEnvironment.Game <- game.Xna
    )
    let desktop : Desktop = new Desktop ()
    let menu : Menu = new Menu ()
    let root : 'root =
        Activator.CreateInstance (typeof<'root>, [| |])
        :?> 'root

    do (
        desktop.Widgets.Add menu
        //root.GridPositionY <- 1
        root.Top <- 32
        desktop.Widgets.Add root
    )

    override __.LateDraw () =
        game.Batch ()
        //desktop.Bounds <- new Rectangle(0, 0, game.Width, game.Height)
        desktop.Render()
    interface IGui with
        member __.Menu = menu
        member __.Root0 = root :> Widget

    interface IGui<'root> with
        member __.Root = root
