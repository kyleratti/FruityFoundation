namespace FruityFoundation.FsBase
open FruityFoundation.Base.Structures

module Option =
    let toMaybe : 'a option -> Maybe<'a> = function
        | Some x -> x |> Maybe.Create
        | None -> Maybe.Empty ()

    let fromMaybe : Maybe<'a> -> 'a option = function
        | x when x.HasValue -> Some x.Value
        | _ -> None
