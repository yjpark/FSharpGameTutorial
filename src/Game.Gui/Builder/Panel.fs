[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Builder.Panel

open Myra.Graphics2D.UI

type PanelBuilder () =
    inherit WidgetBuilder<Panel> ()
    override __.Zero () = new Panel ()

    [<CustomOperation("add")>]
    member __.Add (widget : Panel, child : Widget) =
        widget.Widgets.Add (child)
        widget
