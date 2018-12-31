[<AutoOpen>]
module Game.Engine.Tile.Map

open System.IO
open TiledSharp
open TexturePackerLoader

open Dap.Prelude

open Game.Engine
open Game.Engine.Base
open TiledSharp

let private getTileSpriteName (tile : TmxTilesetTile) =
    Path.GetFileNameWithoutExtension (tile.Image.Source)

let private loadSprites (entity : IEntity) (tiles : TmxTileset) =
    [
        for kv in tiles.Tiles do
            let name = getTileSpriteName kv.Value
            let sprite = entity.Game.Atlas.SpriteSheet.Sprite name
            //logEntityWarn entity "Load_Sprite" (name, sprite)
            yield (kv.Key, sprite)
    ] |> Map.ofList

type Map (map : TmxMap, entity : IEntity) =
    inherit Component (entity)
    //Note: hard coded with first tileset and first layer
    let tiles = map.Tilesets.[0]
    let layer = map.Layers.[0]
    let center =
        Vector2 (
            float32 (map.TileWidth * map.Width / 2),
            float32 (map.TileHeight * map.Height / 2)
        )
    let sprites : Map<int, SpriteFrame> = loadSprites entity tiles
    override __.Draw () =
        let render = entity.Game.Graphics.SpriteRender
        for tile in layer.Tiles do
            let gid = tile.Gid
            if gid <> 0 then
                sprites
                |> Map.tryFind (gid - 1)
                |> Option.iter (fun sprite ->
                    let x = float32 (tile.X * map.TileWidth)
                    let y = float32 (tile.Y * map.TileHeight)
                    render.Draw (sprite, Vector2(x, y) - center)
                )
    static member  Create (map : TmxMap) (entity : IEntity) =
        Map (map, entity)
        :> IComponent