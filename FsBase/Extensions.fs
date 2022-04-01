namespace FruityFoundation.FsBase

open System.Runtime.CompilerServices
open FruityFoundation.Base.Structures

[<Extension>]
type Extensions () =
    [<Extension>]
    static member ToMaybe (opt : 'a option) =
        match opt with
        | Some x -> x |> Maybe.Create
        | None -> Maybe.Empty ()

    [<Extension>]
    static member ToFSharpOption (opt : 'a Maybe) =
        if opt.HasValue then Some opt.Value else None