[<AutoOpen>]
module Tank.Core.Game

open TexturePackerLoader
open Myra
open Myra.Graphics2D.UI

open Game.Engine
open Game.Engine.Tile

open Tank.Content
open Myra

open Dap.Prelude

let loadMap (game : IGame) =
    let map = game.Root.AddChild "map"
    map.AddComponent <| Map.Create Maps.First

let param =
    GameParam.Create("Tank", Textures.Tank, clearColor = Color.Black)
    |> withExitKey Keys.Escape
    |> withSetup loadMap
    |> withAddon TestAddon.Create

let tank (initialize : GameParam -> GameParam) : IGame =
    param
    |> initialize
    |> Game.create
