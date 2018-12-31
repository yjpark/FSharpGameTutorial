module Tank.Sandbox.BarrelGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

let private addButton (x : int) (y : int) (t : string) =
    button {
        text t
        pos x y
        size 64 64
        onUp (fun _args ->
            ()
        )
    }

let init (x : int) (y : int) (gui : IGui<Panel>) =
    gui.AddChildrenWithOffset (x, y,
        label {
            text "Barrel"
            pos 0 0
        },
        addButton 68 32 "^",
        addButton 0 32 "<",
        addButton 136 32 ">"
    )