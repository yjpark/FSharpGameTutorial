[<AutoOpen>]
module Game.Gui.Types

open System

open Game.Engine

[<Literal>]
let GuiKind = "Gui"

type Widget = Myra.Graphics2D.UI.Widget
type TextButton = Myra.Graphics2D.UI.TextButton

type Menu = Myra.Graphics2D.UI.HorizontalMenu
type MenuItem = Myra.Graphics2D.UI.MenuItem

type Container = Myra.Graphics2D.UI.MultipleItemsContainer
type Panel = Myra.Graphics2D.UI.Panel
type Grid = Myra.Graphics2D.UI.Grid
type ScrollPane = Myra.Graphics2D.UI.ScrollPane

type IGui =
    inherit IAddon
    abstract Menu : Menu with get
    abstract Root0 : Widget with get

type IGui<'root when 'root :> Widget> =
    inherit IGui
    abstract Root : 'root with get
