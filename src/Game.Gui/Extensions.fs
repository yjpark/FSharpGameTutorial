[<AutoOpen>]
module Game.Gui.Extensions

open System

open Myra.Graphics2D.UI

type MultipleItemsContainer with
    member this.AddChildren ([<ParamArray>] children : Widget array) =
        children
        |> Array.iter this.Widgets.Add

type HorizontalMenu with
    member this.AddItems ([<ParamArray>] items : MenuItem array) =
        items
        |> Array.iter this.Items.Add
