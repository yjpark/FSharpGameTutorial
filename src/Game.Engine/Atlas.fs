[<AutoOpen>]
module Game.Engine.Atlas

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader

type Atlas = {
    SpriteSheet : SpriteSheet
} with
    static member Create (spriteSheet : SpriteSheet) : Atlas =
        {
            SpriteSheet = spriteSheet
        }
