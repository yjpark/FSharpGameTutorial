[<AutoOpen>]
module Tank.Core.TestAddon

open TexturePackerLoader
open Myra
open Myra.Graphics2D.UI

open Game.Engine
open Game.Engine.Base

open Tank.Content

type TestAddon (game : IGame) =
    inherit Addon (game)
    let mutable testSprite : SpriteFrame = game.Atlas.SpriteSheet.Sprite (Sprites.TankBody_blue)

    static member Create g = new TestAddon (g)

    override __.LateDraw () =
        game.Graphics.SpriteRender.Draw (testSprite, Vector2(100.0f, 100.0f))
