[<AutoOpen>]
module Tank.Core.Game

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader

open Tank.Content

type BaseGame = Microsoft.Xna.Framework.Game

type Graphics = {
    Device : GraphicsDevice
    SpriteBatch : SpriteBatch
    SpriteRender : SpriteRender
    SpriteSheet : SpriteSheet
}

type Game () =
    inherit BaseGame ()

    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable graphics : Graphics option = None

    let mutable testSprite : SpriteFrame option = None
    member private this.Init () =
        this.Content.RootDirectory <- Tank.Content.Const.Root
        graphicsManager <- Some <| new GraphicsDeviceManager (this)

    static member CreateAndRun () =
        let game = new Game ()
        game.Init ()
        game.Run ()
        game

    member __.Graphics = graphics |> Option.get

    override this.Initialize () =
        let spriteBatch = new SpriteBatch (this.GraphicsDevice)
        let spriteSheetLoader = new SpriteSheetLoader(this.Content, this.GraphicsDevice)
        graphics <- Some {
            Device = this.GraphicsDevice
            SpriteBatch = spriteBatch
            SpriteRender = new SpriteRender (spriteBatch)
            SpriteSheet = spriteSheetLoader.Load(Tank.Content.Const.Texture)
        }
        testSprite <- Some <| this.Graphics.SpriteSheet.Sprite (Sprites.TankBody_huge);
        base.IsMouseVisible <- true
        base.Initialize ()

    override this.Update (gameTime : GameTime) =
        base.Update (gameTime)

    override this.Draw (gameTime : GameTime) =
        this.Graphics.Device.Clear (Color.Black)
        this.Graphics.SpriteBatch.Begin ()
        this.Graphics.SpriteRender.Draw (testSprite.Value, Vector2(100.0f, 100.0f))
        this.Graphics.SpriteBatch.End ()
        base.Draw (gameTime)

