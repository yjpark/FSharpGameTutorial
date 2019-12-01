[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Builder.Text

open System
open Myra.Graphics2D.UI
open System

type LabelBuilder () =
    inherit WidgetBuilder<Label> ()
    override __.Zero () = new Label ()

    [<CustomOperation("text")>]
    member __.Text (widget : Label, v : string) =
        widget.Text <- v
        widget
