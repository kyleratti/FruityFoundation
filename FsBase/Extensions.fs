namespace FruityFoundation.FsBase
open System.Collections.Generic
open System.Runtime.CompilerServices
open FruityFoundation.Base.Structures

module Array =
    let toReadOnlyCollection (a : 'a array) = a :> 'a IReadOnlyCollection

module Option =
    let toMaybe : 'a option -> Maybe<'a> = function
        | Some x -> x |> Maybe.Create
        | None -> Maybe.Empty ()

    let fromMaybe : Maybe<'a> -> 'a option = function
        | x when x.HasValue -> Some x.Value
        | _ -> None

module ValueOption =
    let toMaybe : 'a ValueOption -> Maybe<'a> = function
        | ValueSome x -> x |> Maybe.Create
        | ValueNone -> Maybe.Empty ()

    let fromMaybe : Maybe<'a> -> 'a ValueOption = function
        | x when x.HasValue -> ValueSome x.Value
        | _ -> ValueNone

type OptionMaybeInterop =
    [<Extension>]
    static member ToMaybe (x : 'a option) = Option.toMaybe x
    [<Extension>]
    static member ToMaybe (x : 'a ValueOption) = ValueOption.toMaybe x
    [<Extension>]
    static member ToOption (x : 'a Maybe) = Option.fromMaybe x
    [<Extension>]
    static member ToValueOption (x : 'a Maybe) = ValueOption.fromMaybe x
