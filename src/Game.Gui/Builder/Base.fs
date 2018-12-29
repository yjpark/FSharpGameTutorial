[<AutoOpen>]
module Game.Gui.Builder.Base

open System
open Myra.Graphics2D.UI

[<AbstractClass>]
type WidgetBuilder<'widget when 'widget :> Widget> () =
    member this.Yield (_ : 'a) = this.Zero ()
    abstract Zero : unit -> 'widget

    [<CustomOperation("id")>]
    member __.Id (widget : 'widget, v : string) =
        widget.Id <- v
        widget
    [<CustomOperation("left")>]
    member __.Left (widget : 'widget, v : int) =
        widget.Left <- v
        widget
    [<CustomOperation("top")>]
    member __.Top (widget : 'widget, v : int) =
        widget.Top <- v
        widget
    [<CustomOperation("width")>]
    member __.Width (widget : 'widget, v : int) =
        widget.Width <- Nullable v
        widget
    [<CustomOperation("height")>]
    member __.Height (widget : 'widget, v : int) =
        widget.Height <- Nullable v
        widget
    [<CustomOperation("pos")>]
    member __.Pos (widget : 'widget, l : int, t : int) =
        widget.Left <- l
        widget.Top <- t
        widget
    [<CustomOperation("size")>]
    member __.Size (widget : 'widget, w : int, h : int) =
        widget.Width <- Nullable w
        widget.Height <- Nullable h
        widget
    [<CustomOperation("rect")>]
    member __.Rect (widget : 'widget, l : int, t : int, w : int, h : int) =
        widget.Left <- l
        widget.Top <- t
        widget.Width <- Nullable w
        widget.Height <- Nullable h
        widget
