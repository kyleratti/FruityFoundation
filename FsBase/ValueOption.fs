module FruityFoundation.FsBase.ValueOption

open FruityFoundation.Base.Structures

let toMaybe : 'a ValueOption -> Maybe<'a> = function
    | ValueSome x -> x |> Maybe.Create
    | ValueNone -> Maybe.Empty ()

let fromMaybe : Maybe<'a> -> 'a ValueOption = function
    | x when x.HasValue -> ValueSome x.Value
    | _ -> ValueNone
