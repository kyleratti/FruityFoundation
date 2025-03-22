module FruityFoundation.Tests.DataAccess.Abstractions.FSharp.DbDataReaderTests

open System.Collections.Generic
open System.Data.Common
open System.Threading
open FSharp.Control
open FakeItEasy
open FruityFoundation.DataAccess.Abstractions.FSharp.DbDataReader
open NUnit.Framework
open FsUnit

let fakeReader = A.Fake<DbDataReader> ()

[<Test>]
let DbDataReader_ToTaskSeq_Yields_Reader_When_ReadAsync_True () = task {
    // Arrange
    A.CallTo(fun () -> fakeReader.ReadAsync(A<CancellationToken>.Ignored))
        .Returns(true).NumberOfTimes(4) |> ignore
    A.CallTo(fun () -> fakeReader.GetInt32(0))
        .ReturnsNextFromSequence([|1;2;3;4|])

    // Act
    let! result =
        fakeReader
        |> toTaskSeq CancellationToken.None
        |> TaskSeq.map (fun reader -> reader.GetInt32 0)
        |> TaskSeq.toArrayAsync

    // Assert
    result |> should haveLength 4
    result |> should equal [|1;2;3;4|]
    A.CallTo(fun () -> fakeReader.DisposeAsync ())
        .MustHaveHappenedOnceExactly () |> ignore
}
