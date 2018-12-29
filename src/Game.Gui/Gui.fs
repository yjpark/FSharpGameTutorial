[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Gui

open Game.Engine
open Game.Gui.Internal

[<Literal>]
let Kind = "Gui"

let create (game : IGame) =
    let gui = new Gui (Kind, game)
    gui :> IGui