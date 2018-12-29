[<AutoOpen>]
module Game.Gui.Internal.Gui

open Myra
open Myra.Graphics2D.UI

open Game.Engine
open Game.Gui

type internal Gui (kind : string, game : IGame) =
    inherit BaseAddon (kind, game)

    do (
        MyraEnvironment.Game <- game.Xna
    )
    let root : Desktop = new Desktop ()

    override __.Draw () =
        root.Bounds <- new Rectangle(0, 0, game.Width, game.Height)
        root.Render()
    interface IGui with
        member __.Root = root
