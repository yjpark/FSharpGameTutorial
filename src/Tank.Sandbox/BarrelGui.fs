module Tank.Sandbox.BarrelGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

open Tank.Core

let private rotate (barrel : IEntity) (a : float32) =
    fun _args ->
        barrel.Transform.Angle <- barrel.Transform.Angle + a

let init (x : int) (y : int) (gui : IGui<Panel>) =
    let tank = gui.Game.GetAddon<TankAddon> ()
    gui.AddChildrenWithOffset (x, y,
        label {
            text "Barrel"
            pos 0 0
        },
        boxButton 68 32 "^" ignore,
        boxButton 0 32 "<" <| rotate tank.BarrelBase -45.0f,
        boxButton 136 32 ">" <| rotate tank.BarrelBase 45.0f
    )