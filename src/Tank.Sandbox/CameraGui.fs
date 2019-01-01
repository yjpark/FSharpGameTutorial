module Tank.Sandbox.CameraGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

let private zoom (camera : ICamera) (factor : float32) =
    fun _args ->
        camera.Zoom <- camera.Zoom * factor

let private pan (camera : ICamera) ((offsetX, offsetY) : float32 * float32) =
    fun _args ->
        camera.Position <- camera.Position + Vector2 (offsetX, offsetY) / camera.Zoom

let init (x : int) (y : int) (gui : IGui<Panel>) =
    let camera = gui.Game.Camera
    gui.AddChildrenWithOffset (x, y,
        label {
            text "Camera"
            pos 0 0
        },
        boxButton 0 32 "-" <| zoom camera 0.618f,
        boxButton 136 32 "+" <| zoom camera 1.618f,
        boxButton 68 32 "^" <| pan camera (0.0f, -8.0f),
        boxButton 68 100 "_" <| pan camera (0.0f, 8.0f),
        boxButton 0 100 "<" <| pan camera (-8.0f, 0.0f),
        boxButton 136 100 ">" <| pan camera (8.0f, 0.0f)
    )