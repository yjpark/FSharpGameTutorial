[<AutoOpen>]
module Tank.Core.Game

open TexturePackerLoader

open Game.Engine
open Tank.Content

let param = GameParam.Create(Textures.Tank, clearColor = Color.Black)

type Game () =
    inherit BaseGame (param)
    let mutable testSprite : SpriteFrame option = None

    static member CreateAndRun () =
        let game = new Game ()
        game.Setup ()
        game.Run ()
        game
    override this.DoInit () =
        testSprite <- Some <| this.Atlas.SpriteSheet.Sprite (Sprites.TankBody_huge);
    override this.DoDraw () =
        this.Graphics.SpriteRender.Draw (testSprite.Value, Vector2(100.0f, 100.0f))
