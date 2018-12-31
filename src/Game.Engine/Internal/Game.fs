[<AutoOpen>]
module Game.Engine.Internal.Game

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader
open Comora

open Dap.Prelude
open Game.Engine
open Microsoft.Xna.Framework.Graphics

type internal Game (param : GameParam) =
    inherit Microsoft.Xna.Framework.Game ()
    let logger : ILogger = getLogger param.Name
    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable graphics : Graphics option = None
    let mutable camera : Camera option = None
    let mutable atlas : Atlas option = None
    let mutable time : GameTime = new GameTime()
    let mutable root : IEntity option = None
    let mutable addons : IAddon list = []
    member this.Setup (contentRoot : string) =
        this.Content.RootDirectory <- contentRoot
        let graphics = new GraphicsDeviceManager (this)
        graphics.PreferredBackBufferWidth <- param.Width
        graphics.PreferredBackBufferHeight <- param.Height
        graphics.HardwareModeSwitch <- true
        graphics.ApplyChanges ()
        graphicsManager <- Some graphics
        root <- Some (Entity (this.AsGame, None, "") :> IEntity)

    override this.Initialize () =
        let spriteBatch = new SpriteBatch (this.GraphicsDevice)
        let spriteSheetLoader = new SpriteSheetLoader(this.Content, this.GraphicsDevice)
        graphics <- Some {
            Device = this.GraphicsDevice
            SpriteBatch = spriteBatch
            SpriteRender = new SpriteRender (spriteBatch)
            SpriteSheetLoader = spriteSheetLoader
        }
        camera <- Some <| new Camera (this.GraphicsDevice)
        camera.Value.LoadContent ()
        atlas <- Some <| Atlas.Create ^<| spriteSheetLoader.Load (param.AtlasImage)
        base.IsMouseVisible <- param.IsMouseVisible
        base.Initialize ()
        param.Initializers
        |> List.iter (fun initializer -> initializer this)
    override this.Update (gameTime : GameTime) =
        time <- gameTime
        param.ExitKey
        |> Option.iter (fun key ->
            if Keyboard.isKeyDown key then
                this.Exit ()
        )
        addons
        |> List.iter (fun addon -> addon.Update ())
        root
        |> Option.iter (fun r -> r.Update ())
        addons
        |> List.iter (fun addon -> addon.LateUpdate ())
        base.Update (gameTime)
    override __.Draw (gameTime : GameTime) =
        time <- gameTime
        param.ClearColor
        |> Option.iter (fun color ->
            graphics.Value.Device.Clear (color)
        )
        graphics.Value.Begin (camera.Value :> ICamera)
        addons
        |> List.iter (fun addon -> addon.Draw ())
        root
        |> Option.iter (fun r -> r.Draw ())
        addons
        |> List.iter (fun addon -> addon.LateDraw ())
        graphics.Value.End ()
        base.Draw (gameTime)
    interface IGame with
        member this.Xna = this :> Microsoft.Xna.Framework.Game
        member __.Param = param
        member __.Graphics = graphics |> Option.get
        member __.Camera = camera |> Option.get :> ICamera
        member __.Atlas = atlas |> Option.get
        member __.Time = time
        member __.Width = graphicsManager.Value.PreferredBackBufferWidth
        member __.Height = graphicsManager.Value.PreferredBackBufferHeight
        member __.Root = root |> Option.get
        member this.Reset () =
            root <- Some (Entity (this.AsGame, None, "") :> IEntity)
        member __.Addons = addons
        member this.Register' (addon : IAddon) =
            addons <- addons @ [addon]
        member this.Register (create : IGame -> IAddon) =
            this.AsGame.Register' <| create this
        member __.Batch (?sortMode : SpriteSortMode) =
            graphics.Value.Batch (camera.Value :> ICamera, ?sortMode = sortMode)
    member this.AsGame = this :> IGame
    interface ILogger with
        member __.Log evt = logger.Log evt
