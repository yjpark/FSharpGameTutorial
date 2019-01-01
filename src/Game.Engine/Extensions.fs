[<AutoOpen>]
module Game.Engine.Extensions

open System

open Transform

type Transform2D with
    member this.Angle
        with get () = MathF.radianToAngle this.Rotation
        and set (a : float32) = this.Rotation <- MathF.angleToRadian a
    member this.AbsoluteAngle
        with get () = MathF.radianToAngle this.AbsoluteRotation


