[<AutoOpen>]
module Game.Engine.Sprite

open System
open TexturePackerLoader

open Dap.Prelude

open Game.Engine
open Game.Engine.Base
open TiledSharp

type Sprite (_name : string, entity : IEntity) =
    inherit Component (entity)
    let mutable sprite = entity.Game.Atlas.Sprite _name
    let mutable color : Color = Color.White
    override __.Draw () =
        let render = entity.Game.Graphics.SpriteRender
        render.Draw (sprite, entity.Transform.AbsolutePosition,
                        color = Nullable color,
                        rotation = entity.Transform.AbsoluteRotation,
                        scale = entity.Transform.AbsoluteScale.X)
    member __.Sprite
        with get () = sprite
        and set (s : SpriteFrame) = sprite <- s
    member __.SetSprite (name : string) =
        sprite <- entity.Game.Atlas.Sprite name
    member __.Color
        with get () = color
        and set (c : Color) = color <- c
    static member Create n (entity : IEntity) =
        Sprite (n, entity)
        :> IComponent