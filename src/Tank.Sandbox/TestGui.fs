module Tank.Sandbox.TestGui

open System
open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

open Tank.Core

let private pivot (hint : Label) (entity : IEntity) (offset : float32) =
    fun _args ->
        entity.Transform.Position <- entity.Transform.Position + Vector2(0.0f, offset)
        hint.Text <- sprintf "Barrel: %f" entity.Transform.Position.Y

let init (x : int) (y : int) (gui : IGui<Panel>) =
    let tank = gui.Game.GetAddon<TankAddon> ()
    let hint =
        label {
            text "Test"
            pos 0 0
        }
    gui.AddChildrenWithOffset (x, y,
        hint,
        boxButton 0 32 "-" <| pivot hint tank.Barrel -1.0f,
        boxButton 68 32 "^" <| pivot hint tank.Barrel 1.0f
        (*
        boxButton 136 32 "" ignore,
        boxButton 0 100 "" ignore,
        boxButton 68 100 "" ignore,
        boxButton 136 100 "" ignore
        *)
    )