namespace FruityFoundation.FsBase
open System.Collections.Generic
open FruityFoundation.Base.Structures

module Array =
    let toReadOnlyCollection (a : 'a array) = a :> 'a IReadOnlyCollection

module Option =
    let toMaybe : 'a option -> Maybe<'a> = function
        | Some x -> x |> Maybe.Just
        | None -> Maybe.Empty ()

    let fromMaybe : Maybe<'a> -> 'a option = function
        | x when x.HasValue -> Some x.Value
        | _ -> None
