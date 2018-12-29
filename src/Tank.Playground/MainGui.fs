module Tank.Playground.MainGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui

open Tank.Content

let create game =
    Gui.create game
    |> CameraGui.add 8 8