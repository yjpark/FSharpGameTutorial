[<AutoOpen>]
module Game.Gui.GuiAddon

open Myra
open Myra.Graphics2D.UI

open Game.Engine

[<Literal>]
let Kind = "Gui"

type GuiAddon (kind : string, game : IGame) =
    inherit BaseAddon (kind, game)

    do (
        MyraEnvironment.Game <- game.Xna
    )
    let root : Desktop = new Desktop ()

    new (g : IGame) =
        new GuiAddon(Kind, g)

    static member Create g = new GuiAddon (g)

    member __.Root = root
    override __.Draw () =
        root.Bounds <- new Rectangle(0, 0, game.Width, game.Height)
        root.Render()
