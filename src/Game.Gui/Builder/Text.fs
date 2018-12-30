[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Builder.Text

open System
open Myra.Graphics2D.UI
open System

type TextBlockBuilder () =
    inherit WidgetBuilder<TextBlock> ()
    override __.Zero () = new TextBlock ()

    [<CustomOperation("text")>]
    member __.Text (widget : TextBlock, v : string) =
        widget.Text <- v
        widget