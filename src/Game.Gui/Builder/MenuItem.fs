[<AutoOpen>]
[<RequireQualifiedAccess>]
module Game.Gui.Builder.MenuItem

open System
open Myra.Graphics2D.UI
open System

type MenuItemBuilder () =
    member this.Yield (_ : 'a) = this.Zero ()
    member __.Zero () = new MenuItem ()

    [<CustomOperation("id")>]
    member __.Id (item : MenuItem, v : string) =
        item.Id <- v
        item
    [<CustomOperation("text")>]
    member __.Text (item : MenuItem, v : string) =
        item.Text <- v
        item
    [<CustomOperation("onSelected")>]
    member __.OnSelected (item : MenuItem, onSelected : EventArgs -> unit) =
        item.Selected.Add onSelected
        item
