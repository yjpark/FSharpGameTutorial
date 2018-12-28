[<AutoOpen>]
module Tank.Playground.Gui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui

open Tank.Content

type Gui (game : IGame) =
    inherit GuiAddon (game)

    do (
        let menu = new MainMenu ()
        menu.Quit.Selected.Add (fun _evt -> game.Xna.Exit ())
        base.Root.Widgets.Add (menu)
    )

    static member Create g = new Gui (g)

    override this.Update () =
        if Keyboard.isKeyDown Keys.Space then
            let msg = Dialog.CreateMessageBox ("Test", "Test")
            msg.ShowModal (this.Root)
