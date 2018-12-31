[<AutoOpen>]
module Game.Engine.Addon.Mask

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open Game.Engine
open Game.Engine.Base

type Mask (rect : Rectangle, color : Color, game : IGame) =
    inherit Addon(game)
    let texture = new Texture2D (game.Graphics.Device, 1, 1)
    do (
        texture.SetData ( [| color |] )
    )
    override __.LateDraw () =
        game.Graphics.End ()
        game.Graphics.SpriteBatch.Begin ()
        game.Graphics.SpriteBatch.Draw (texture, rect, color)
        game.Batch ()
    static member Create rect color game = new Mask (rect, color, game)