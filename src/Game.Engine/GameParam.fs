[<AutoOpen>]
module Game.Engine.GameParam

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open Dap.Prelude

type GameParam = {
    AtlasImage : string
    IsMouseVisible : bool
    ClearColor : Color option
} with
    static member Create (atlasImage : string, ?isMouseVisible : bool, ?clearColor : Color) : GameParam =
        {
            AtlasImage = atlasImage
            IsMouseVisible = defaultArg isMouseVisible true
            ClearColor = clearColor
        }