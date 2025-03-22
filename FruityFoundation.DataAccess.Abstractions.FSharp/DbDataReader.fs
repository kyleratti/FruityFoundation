module FruityFoundation.DataAccess.Abstractions.FSharp.DbDataReader

open System.Data.Common
open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open FSharp.Control

let toTaskSeq ([<EnumeratorCancellation>] cancellationToken : CancellationToken) (reader : DbDataReader Task) = taskSeq {
    use! reader = reader

    while! reader.ReadAsync cancellationToken do
        yield reader
}
