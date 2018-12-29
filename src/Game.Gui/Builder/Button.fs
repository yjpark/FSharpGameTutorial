[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Builder.Button

open System
open Myra.Graphics2D.UI
open System

type TextButtonBuilder () =
    inherit WidgetBuilder<TextButton> ()
    override __.Zero () = new TextButton ()

    [<CustomOperation("text")>]
    member __.Text (widget : TextButton, v : string) =
        widget.Text <- v
        widget
    [<CustomOperation("onUp")>]
    member __.OnUp (widget : TextButton, onUp : EventArgs -> unit) =
        widget.Up.Add onUp
        widget
    [<CustomOperation("onDown")>]
    member __.OnDown (widget : TextButton, onDown : EventArgs -> unit) =
        widget.Down.Add onDown
        widget
