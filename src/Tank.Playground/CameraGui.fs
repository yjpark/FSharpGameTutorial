module Tank.Playground.CameraGui

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude

open Game.Engine
open Game.Gui
open Game.Gui.Builder

let private addPanButton (x : int) (y : int) (t : string) (camera : ICamera) ((offsetX, offsetY) : float32 * float32) =
    button {
        text t
        pos x y
        size 64 64
        onUp (fun _args ->
            camera.Position <- camera.Position + Vector2 (offsetX, offsetY)
        )
    }

let init (gui : IGui<Panel>) =
    let camera = gui.Game.Camera
    gui.AddChildren (
        label {
            text "Camera Controls"
            pos 8 0
        },
        addPanButton 100 50 "U" camera (0.0f, -8.0f),
        addPanButton 100 118 "D" camera (0.0f, 8.0f),
        addPanButton 32 118 "L" camera (-8.0f, 0.0f),
        addPanButton 168 118 "R" camera (8.0f, 0.0f)
    )