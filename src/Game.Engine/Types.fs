[<AutoOpen>]
module Game.Engine.Types

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open TexturePackerLoader
open Comora

open Dap.Prelude
open Microsoft.Xna.Framework.Graphics

type Color = Microsoft.Xna.Framework.Color
type Vector2 = Microsoft.Xna.Framework.Vector2
type Rectangle = Microsoft.Xna.Framework.Rectangle

type Transform2D = Transform.Transform2D

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
} with
    member this.Begin (camera : ICamera, ?sortMode : SpriteSortMode) =
        let sortMode = defaultArg sortMode SpriteSortMode.Deferred
        this.SpriteBatch.Begin (camera, sortMode)
    member this.End () =
        this.SpriteBatch.End ()
    member this.Batch (camera : ICamera, ?sortMode : SpriteSortMode) =
        this.End ()
        this.Begin (camera, ?sortMode = sortMode);

and IEntity =
    abstract Game : IGame with get
    abstract Path : string with get
    abstract Key : string with get
    abstract Active : bool with get, set
    abstract Parent : IEntity option with get
    abstract Children : IEntity list with get
    abstract Transform : Transform2D with get
    abstract Components : IComponent list with get
    abstract TryFindChild : string -> IEntity option
    abstract TryFindComponent<'comp when 'comp :> IComponent> : unit -> 'comp option
    abstract AddChild : string -> IEntity
    abstract AddComponent' : IComponent -> unit
    abstract AddComponent : (IEntity -> IComponent) -> unit
    abstract Update : unit -> unit
    abstract Draw : unit -> unit

and IComponent =
    abstract Entity : IEntity with get
    abstract Enabled : bool with get, set
    abstract Update : unit -> unit
    abstract Draw : unit -> unit

and IGame =
    inherit IDisposable
    inherit ILogger
    abstract Xna : Microsoft.Xna.Framework.Game with get
    abstract Param : GameParam with get
    abstract Graphics : Graphics with get
    abstract Camera : ICamera with get
    abstract Atlas : SpriteSheet with get
    abstract Time : GameTime with get
    abstract Width : int with get
    abstract Height : int with get
    abstract Root : IEntity with get
    abstract Reset : unit -> unit
    abstract Addons : IAddon list with get
    abstract TryFindAddon<'addon when 'addon :> IAddon> : unit -> 'addon option
    abstract Register' : IAddon -> unit
    abstract Register : (IGame -> IAddon) -> unit
    abstract Batch : ?sortMode : SpriteSortMode -> unit

and IAddon =
    inherit ILogger
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
