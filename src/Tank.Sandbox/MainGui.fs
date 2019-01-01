module Tank.Sandbox.MainGui

open System
open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

open Tank.Content

let private initRoot (gui : IGui<Panel>) =
    gui

let private initMenu (gui : IGui) =
    gui.AddMenuItems (
        menuItem {
            text "Quit"
            onSelected (fun _args -> gui.Game.Xna.Exit ())
        }
    )

let create game =
    Gui.create<Panel> game
    |> CameraGui.init 8 0
    |> BarrelGui.init 8 200
    |> TankGui.init 8 330
    |> TestGui.init 8 530
    |> initRoot
    |> initMenu