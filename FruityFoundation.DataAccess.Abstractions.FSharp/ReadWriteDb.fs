[<RequireQualifiedAccess>]
module FruityFoundation.DataAccess.Abstractions.FSharp.ReadWriteDb

open System.Collections.Generic
open System.Threading
open FSharp.Control
open FruityFoundation.DataAccess.Abstractions
open FruityFoundation.FsBase

let private toKeyValuePair (parms : (string * obj) seq) =
    parms
    |> Seq.map (fun (name, value) -> KeyValuePair(name, value))

let query<'a> (connection : IDatabaseConnection<ReadWrite>) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = task {
    return! connection.Query<'a>(sql, parms |> toKeyValuePair, cancellationToken)
}

let queryUnbuffered<'a> (connection : IDatabaseConnection<ReadWrite>) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = taskSeq {
    yield! connection.QueryUnbuffered<'a>(sql, parms |> toKeyValuePair, cancellationToken)
}

let querySingle<'a> (connection : IDatabaseConnection<ReadWrite>) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = task {
    return! connection.QuerySingle<'a>(sql, parms |> toKeyValuePair, cancellationToken)
}

let tryQueryFirst<'a> (connection : ReadOnly IDatabaseConnection) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = task {
    let! result = connection.TryQueryFirst<'a>(sql, parms |> toKeyValuePair, cancellationToken)
    return result |> Option.fromMaybe
}

let execute (connection : IDatabaseConnection<ReadWrite>) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = task {
    return! connection.Execute(sql, parms |> toKeyValuePair, cancellationToken)
}

let executeScalar<'a> (connection : IDatabaseConnection<ReadWrite>) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = task {
    return! connection.ExecuteScalar<'a>(sql, parms |> toKeyValuePair, cancellationToken)
}

let executeReader (connection : IDatabaseConnection<ReadWrite>) (cancellationToken : CancellationToken) (sql : string) (parms : (string * obj) seq) = task {
    return! connection.ExecuteReader(sql, parms |> toKeyValuePair, cancellationToken)
}
