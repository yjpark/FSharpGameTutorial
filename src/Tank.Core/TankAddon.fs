[<AutoOpen>]
module Tank.Core.TankAddon

open TexturePackerLoader
open Myra
open Myra.Graphics2D.UI

open Game.Engine
open Game.Engine.Base
open Game.Engine.Tile

open Tank.Content

let BarrelOffset = Vector2 (0.0f, 30.0f)

let private loadMap (game : IGame) =
    let map = game.Root.AddChild "map"
    map.AddComponent <| Map.Create Maps.First


type TankAddon (game : IGame) =
    inherit Addon (game)
    let map = loadMap (game)
    let body = game.Root.AddChild "body"
    let barrelBase = body.AddChild "barrel_base"
    let barrel = barrelBase.AddChild "barrel"
    do (
        body.AddComponent <| Sprite.Create Sprites.TankBody_blue
        barrel.AddComponent <| Sprite.Create Sprites.TankBlue_barrel1
        barrel.Transform.Position <- BarrelOffset
    )
    member __.Map = map
    member __.Body = body
    member __.BarrelBase = barrelBase
    member __.Barrel = barrel
    static member Create g = new TankAddon (g)
