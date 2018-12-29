[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Builder.Button

open Myra.Graphics2D.UI

type TextButtonBuilder () =
    inherit WidgetBuilder<TextButton> ()
    override __.Zero () = new TextButton ()

    [<CustomOperation("text")>]
    member __.Id (widget : TextButton, v : string) =
        widget.Text <- v
        widget
