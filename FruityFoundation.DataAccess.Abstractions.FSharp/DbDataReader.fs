module FruityFoundation.DataAccess.Abstractions.FSharp.DbDataReader

open System.Data.Common
open System.Runtime.CompilerServices
open System.Threading
open FSharp.Control

let toTaskSeq ([<EnumeratorCancellation>] cancellationToken : CancellationToken) (reader : DbDataReader) = taskSeq {
    use reader = reader

    while! reader.ReadAsync cancellationToken do
        yield reader
}
