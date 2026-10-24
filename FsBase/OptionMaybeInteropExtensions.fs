namespace FruityFoundation.FsBase

open System.Runtime.CompilerServices
open FruityFoundation.Base.Structures

type OptionMaybeInterop =
    [<Extension>]
    static member ToMaybe (x : 'a option) = Option.toMaybe x
    [<Extension>]
    static member ToMaybe (x : 'a ValueOption) = ValueOption.toMaybe x
    [<Extension>]
    static member ToOption (x : 'a Maybe) = Option.fromMaybe x
    [<Extension>]
    static member ToValueOption (x : 'a Maybe) = ValueOption.fromMaybe x
