module Tank.Playground.MainGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

open Tank.Content

let private initMenu (gui : IGui) =
    gui.AddMenuItems (
        menuItem {
            text "Quit"
            onSelected (fun _args -> gui.Game.Xna.Exit ())
        }
    )

let create game =
    Gui.create<Panel> game
    |> CameraGui.init
    |> initMenu