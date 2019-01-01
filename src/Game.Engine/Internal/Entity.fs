[<AutoOpen>]
module Game.Engine.Internal.Entity

open Dap.Prelude

open Game.Engine
open Transform

type internal Entity (game : IGame, parent : IEntity option, key : string) =
    let mutable active : bool = true
    let transform = Transform2D ()
    let mutable children : IEntity list = []
    let mutable components : IComponent list = []

    do (
        parent
        |> Option.iter (fun p ->
            transform.Parent <- p.Transform
        )
    )
    interface IEntity with
        member __.Game = game
        member __.Path =
            parent
            |> Option.map (fun p -> sprintf "%s/%s" p.Path key)
            |> Option.defaultValue key
        member __.Key = key
        member __.Active
            with get () = active
            and set (a : bool) = active <- a
        member __.Parent = parent
        member __.Children = children
        member __.Transform = transform
        member __.Components = components
        member __.TryFindChild (key : string) : IEntity option =
            children
            |> List.tryFind (fun c -> c.Key = key)
        member __.TryFindComponent<'comp when 'comp :> IComponent> () : 'comp option =
            let t = typeof<'comp>
            components
            |> List.tryFind (fun c -> c.GetType () = t)
            |> Option.map (fun c -> c :?> 'comp)
        member this.AddChild (k : string) =
            let child = Entity (game, Some this.AsEntity, k)
            children <- children @ [child]
            child :> IEntity
        member __.AddComponent' (comp : IComponent) =
            components <- components @ [comp]
        member this.AddComponent (create : IEntity -> IComponent) =
            this.AsEntity.AddComponent' <| create this
        member __.Update () =
            if active then
                components
                |> List.iter (fun c ->
                    if c.Enabled then
                        c.Update ()
                )
                children
                |> List.iter (fun c ->
                    if c.Active then
                        c.Update ()
                )
        member __.Draw () =
            if active then
                components
                |> List.iter (fun c ->
                    if c.Enabled then
                        c.Draw ()
                )
                children
                |> List.iter (fun c ->
                    if c.Active then
                        c.Draw ()
                )
    member this.AsEntity = this :> IEntity