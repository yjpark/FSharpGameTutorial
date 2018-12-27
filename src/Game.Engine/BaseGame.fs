[<AutoOpen>]
module Game.Engine.BaseGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader

open Dap.Prelude

[<Literal>]
let ContentRoot = "Content"

type Graphics = {
    Device : GraphicsDevice
    SpriteBatch : SpriteBatch
    SpriteRender : SpriteRender
    SpriteSheetLoader : SpriteSheetLoader
}

type BaseGame (param : GameParam) =
    inherit Microsoft.Xna.Framework.Game ()

    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable graphics : Graphics option = None
    let mutable atlas : Atlas option = None
    let mutable time : GameTime option = None

    member this.Setup () =
        this.Content.RootDirectory <- ContentRoot
        graphicsManager <- Some <| new GraphicsDeviceManager (this)

    member __.Graphics = graphics |> Option.get
    member __.Atlas = atlas |> Option.get
    member __.Time = time |> Option.get

    abstract member DoInit : unit -> unit
    abstract member DoUpdate : unit -> unit
    abstract member DoDraw : unit -> unit
    default __.DoInit () = ()
    default __.DoUpdate () = ()
    default __.DoDraw () = ()

    override this.Initialize () =
        let spriteBatch = new SpriteBatch (this.GraphicsDevice)
        let spriteSheetLoader = new SpriteSheetLoader(this.Content, this.GraphicsDevice)
        graphics <- Some {
            Device = this.GraphicsDevice
            SpriteBatch = spriteBatch
            SpriteRender = new SpriteRender (spriteBatch)
            SpriteSheetLoader = spriteSheetLoader
        }
        atlas <- Some <| Atlas.Create ^<| spriteSheetLoader.Load (param.AtlasImage)
        base.IsMouseVisible <- param.IsMouseVisible
        this.DoInit ()
        base.Initialize ()

    override this.Update (gameTime : GameTime) =
        time <- Some gameTime
        this.DoUpdate ()
        base.Update (gameTime)

    override this.Draw (gameTime : GameTime) =
        time <- Some gameTime
        param.ClearColor
        |> Option.iter (fun color ->
            this.Graphics.Device.Clear (color)
        )
        this.Graphics.SpriteBatch.Begin ()
        this.DoDraw ()
        this.Graphics.SpriteBatch.End ()
        base.Draw (gameTime)

