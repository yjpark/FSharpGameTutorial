module Tank.Playground.CameraGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

let add (l : int) (t : int) (gui : IGui) =
    gui.Root.Widgets.Add (
        panel {
            pos l t
            add (textButton {
                text "Quit"
                size 128 64
                onUp (fun _args -> gui.Game.Xna.Exit ())
            })
        }
    )
    gui