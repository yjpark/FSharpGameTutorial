module Tank.Sandbox.TankGui

open System
open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

open Tank.Core

let private move (entity : IEntity) (speed : float32) =
    fun _args ->
        let r = entity.Transform.AbsoluteRotation
        let dir = Vector2 (-MathF.Sin (r), MathF.Cos (r))
        let offset = dir * speed
        entity.Transform.Position <- entity.Transform.Position + offset

let private turn (entity : IEntity) (a : float32) =
    fun _args ->
        entity.Transform.Angle <- entity.Transform.Angle + a

let init (x : int) (y : int) (gui : IGui<Panel>) =
    let tank = gui.Game.GetAddon<TankAddon> ()
    let body = tank.Body
    gui.AddChildrenWithOffset (x, y,
        label {
            text "Tank"
            pos 0 0
        },
        boxButton 68 32 "W" <| move body 5.0f,
        boxButton 68 100 "S" <| move body -2.0f,
        boxButton 0 100 "A" <| turn body -90.0f,
        boxButton 136 100 "D" <| turn body 90.0f
    )