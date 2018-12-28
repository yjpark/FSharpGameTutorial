[<AutoOpen>]
module Tank.Core.Game

open TexturePackerLoader
open Myra
open Myra.Graphics2D.UI

open Game.Engine

open Tank.Content
open Myra

open Dap.Prelude

let param =
    GameParam.Create("Tank", Textures.Tank, clearColor = Color.Black)
    |> withExitKey Keys.Escape
    |> withAddon TestAddon.Create

let tank (initialize : GameParam -> GameParam) : IGame =
    param
    |> initialize
    |> Game.create
