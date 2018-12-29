[<AutoOpen>]
module Game.Engine.Internal.Game

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader
open Comora

open Dap.Prelude
open Game.Engine

type internal Game (param : GameParam) =
    inherit Microsoft.Xna.Framework.Game ()
    let logger : ILogger = getLogger param.Name
    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable graphics : Graphics option = None
    let mutable camera : Camera option = None
    let mutable atlas : Atlas option = None
    let mutable time : GameTime = new GameTime()
    let mutable addons : Map<string, IAddon> = Map.empty
    member this.Setup (contentRoot : string) =
        this.Content.RootDirectory <- contentRoot
        let graphics = new GraphicsDeviceManager (this)
        graphics.PreferredBackBufferWidth <- param.Width
        graphics.PreferredBackBufferHeight <- param.Height
        graphics.HardwareModeSwitch <- true
        graphics.ApplyChanges ()
        graphicsManager <- Some graphics

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
        |> Map.iter (fun _kind addon -> addon.Update ())
        base.Update (gameTime)
        addons
        |> Map.iter (fun _kind addon -> addon.LateUpdate ())
    override __.Draw (gameTime : GameTime) =
        time <- gameTime
        param.ClearColor
        |> Option.iter (fun color ->
            graphics.Value.Device.Clear (color)
        )
        graphics.Value.SpriteBatch.Begin (camera.Value)
        addons
        |> Map.iter (fun _kind addon -> addon.Draw ())
        graphics.Value.SpriteBatch.End ()
        base.Draw (gameTime)
        addons
        |> Map.iter (fun _kind addon -> addon.LateDraw ())
    interface IGame with
        member this.Xna = this :> Microsoft.Xna.Framework.Game
        member __.Param = param
        member __.Graphics = graphics |> Option.get
        member __.Camera = camera |> Option.get :> ICamera
        member __.Atlas = atlas |> Option.get
        member __.Time = time
        member __.Width = graphicsManager.Value.PreferredBackBufferWidth
        member __.Height = graphicsManager.Value.PreferredBackBufferHeight
        member __.Addons = addons
        member this.Register (create : IGame -> IAddon) =
            let addon = create this
            let kind = addon.Kind
            match Map.tryFind kind addons with
            | Some addon' ->
                logError this "Register" "Addon_Already_Exist" (kind, addon', addon)
            | None ->
                addons <- Map.add kind addon addons
                logInfo this "Register" "Addon_Added" (kind, addon)
    interface ILogger with
        member __.Log evt = logger.Log evt
