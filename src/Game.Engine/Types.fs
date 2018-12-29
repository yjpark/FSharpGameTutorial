[<AutoOpen>]
module Game.Engine.Types

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader

open Dap.Prelude

type Color = Microsoft.Xna.Framework.Color
type Vector2 = Microsoft.Xna.Framework.Vector2
type Rectangle = Microsoft.Xna.Framework.Rectangle

type GamePad = Microsoft.Xna.Framework.Input.GamePad
type Keyboard = Microsoft.Xna.Framework.Input.Keyboard
type Keys = Microsoft.Xna.Framework.Input.Keys

type ICamera = Comora.ICamera
type Camera = Comora.Camera

type Graphics = {
    Device : GraphicsDevice
    SpriteBatch : SpriteBatch
    SpriteRender : SpriteRender
    SpriteSheetLoader : SpriteSheetLoader
}

type IGame =
    inherit IDisposable
    inherit ILogger
    abstract Xna : Microsoft.Xna.Framework.Game with get
    abstract Param : GameParam with get
    abstract Graphics : Graphics with get
    abstract Camera : ICamera with get
    abstract Atlas : Atlas with get
    abstract Time : GameTime with get
    abstract Width : int with get
    abstract Height : int with get
    abstract Addons : Map<string, IAddon>
    abstract Register : (IGame -> IAddon) -> unit

and IAddon =
    inherit ILogger
    abstract Kind : string with get
    abstract Game : IGame with get
    abstract Update : unit -> unit
    abstract Draw : unit -> unit
    abstract LateUpdate : unit -> unit
    abstract LateDraw : unit -> unit

and GameParam = {
    Name : string
    Width : int
    Height : int
    AtlasImage : string
    IsMouseVisible : bool
    ClearColor : Color option
    ExitKey : Keys option
    Initializers : (IGame -> unit) list
} with
    static member Create (name : string, atlasImage : string, ?width : int, ?height : int, ?isMouseVisible : bool, ?clearColor : Color, ?exitKey : Keys) : GameParam =
        {
            Name = name
            Width = defaultArg width 1280
            Height = defaultArg height 720
            AtlasImage = atlasImage
            IsMouseVisible = defaultArg isMouseVisible true
            ClearColor = clearColor
            ExitKey = exitKey
            Initializers = []
        }
