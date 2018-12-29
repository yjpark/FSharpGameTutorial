[<AutoOpen>]
module Game.Gui.Types

open Game.Engine

[<Literal>]
let GuiKind = "Gui"

type Desktop = Myra.Graphics2D.UI.Desktop
type TextButton = Myra.Graphics2D.UI.TextButton
type Panel = Myra.Graphics2D.UI.Panel

type IGui =
    inherit IAddon
    abstract Root : Desktop with get