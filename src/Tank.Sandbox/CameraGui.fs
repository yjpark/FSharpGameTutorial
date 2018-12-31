module Tank.Sandbox.CameraGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

let private addZoomButton (x : int) (y : int) (t : string) (camera : ICamera) (factor : float32) =
    button {
        text t
        pos x y
        size 64 64
        onUp (fun _args ->
            camera.Zoom <- camera.Zoom * factor
        )
    }

let private addPanButton (x : int) (y : int) (t : string) (camera : ICamera) ((offsetX, offsetY) : float32 * float32) =
    button {
        text t
        pos x y
        size 64 64
        onUp (fun _args ->
            camera.Position <- camera.Position + Vector2 (offsetX, offsetY) / camera.Zoom
        )
    }

let init (x : int) (y : int) (gui : IGui<Panel>) =
    let camera = gui.Game.Camera
    gui.AddChildrenWithOffset (x, y,
        label {
            text "Camera"
            pos 0 0
        },
        addZoomButton 0 32 "-" camera 0.618f,
        addZoomButton 136 32 "+" camera 1.618f,
        addPanButton 68 32 "^" camera (0.0f, -8.0f),
        addPanButton 68 100 "_" camera (0.0f, 8.0f),
        addPanButton 0 100 "<" camera (-8.0f, 0.0f),
        addPanButton 136 100 ">" camera (8.0f, 0.0f)
    )