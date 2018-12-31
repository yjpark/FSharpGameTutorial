[<AutoOpen>]
module Game.Engine.Logging

open Dap.Prelude

let private tplEntityDebug = LogEvent.Template4<string, string, IEntity, obj>(LogLevelDebug, "[{Section}] {Info}: {Entity} {Detail}")

let private tplEntityInfo = LogEvent.Template4<string, string, IEntity, obj>(LogLevelInformation, "[{Section}] {Info}: {Entity} {Detail}")
let private tplEntityWarn = LogEvent.Template4<string, string, IEntity, obj>(LogLevelWarning, "[{Section}] {Warn}: {Entity} {Detail}")
let private tplEntityError = LogEvent.Template4<string, string, IEntity, obj>(LogLevelError, "[{Section}] {Err}: {Entity} {Detail}")

let private tplEntityException = LogEvent.Template4WithException<string, string, IEntity, obj>(LogLevelError, "[{Section}] {Err}: {Entity} {Detail}")

let private tplComponentDebug = LogEvent.Template4<string, string, IComponent, obj>(LogLevelDebug, "[{Section}] {Info}: {Component} {Detail}")

let private tplComponentInfo = LogEvent.Template4<string, string, IComponent, obj>(LogLevelInformation, "[{Section}] {Info}: {Component} {Detail}")
let private tplComponentWarn = LogEvent.Template4<string, string, IComponent, obj>(LogLevelWarning, "[{Section}] {Warn}: {Component} {Detail}")
let private tplComponentError = LogEvent.Template4<string, string, IComponent, obj>(LogLevelError, "[{Section}] {Err}: {Component} {Detail}")

let private tplComponentException = LogEvent.Template4WithException<string, string, IComponent, obj>(LogLevelError, "[{Section}] {Err}: {Component} {Detail}")

let logEntityDebug (entity : IEntity) info detail : unit =
    entity.Game.Log <| tplEntityDebug entity.Path info entity detail

let logEntityInfo (entity : IEntity) info detail : unit =
    entity.Game.Log <| tplEntityInfo entity.Path info entity detail

let logEntityWarn (entity : IEntity) info detail : unit =
    entity.Game.Log <| tplEntityWarn entity.Path info entity detail

let logEntityError (entity : IEntity) info detail : unit =
    entity.Game.Log <| tplEntityError entity.Path info entity detail

let logEntityException (entity : IEntity) info detail e : unit =
    entity.Game.Log <| tplEntityException entity.Path info entity detail e

let private getComponentSection (comp : IComponent) =
    sprintf "%s<%s>" comp.Entity.Path <| (comp.GetType ()).Name

let logComponentDebug (comp : IComponent) info detail : unit =
    comp.Entity.Game.Log <| tplComponentDebug (getComponentSection comp) info comp detail

let logComponentInfo (comp : IComponent) info detail : unit =
    comp.Entity.Game.Log <| tplComponentInfo (getComponentSection comp) info comp detail

let logComponentWarn (comp : IComponent) info detail : unit =
    comp.Entity.Game.Log <| tplComponentWarn (getComponentSection comp) info comp detail

let logComponentError (comp : IComponent) info detail : unit =
    comp.Entity.Game.Log <| tplComponentError (getComponentSection comp) info comp detail

let logComponentException (comp : IComponent) info detail e : unit =
    comp.Entity.Game.Log <| tplComponentException (getComponentSection comp) info comp detail e

