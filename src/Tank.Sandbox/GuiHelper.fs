[<AutoOpen>]
module Tank.Sandbox.GuiHelper

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

open Tank.Core

let boxButton (x : int) (y : int) (t : string) upAction =
    button {
        text t
        pos x y
        size 64 64
        onUp upAction
    }