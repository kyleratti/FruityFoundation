module FruityFoundation.Tests.DataAccess.Abstractions.FSharp.ReadWriteDbTests

open System.Collections.Generic
open System.Threading
open FSharp.Control
open FakeItEasy
open FruityFoundation.DataAccess.Abstractions
open FruityFoundation.DataAccess.Abstractions.FSharp
open NUnit.Framework

let fakeDbConnection : IDatabaseConnection<ReadWrite> = A.Fake<IDatabaseConnection<ReadWrite>> ()

[<Test>]
let Db_Query_Calls_IDatabaseConnection_Query_NoParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = Array.empty

    // Act
    let! _ = task {
        return! (sql, parms) ||> ReadWriteDb.query fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.Query(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(Seq.isEmpty),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_Query_Calls_IDatabaseConnection_Query_WithParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = [| ("@id", box 1) |]

    // Act
    let! result = task {
        return! (sql, parms) ||> ReadWriteDb.query fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.Query(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(fun x ->
            Seq.length x = 1 && Seq.head x = KeyValuePair("@id", box 1)),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_QueryUnbuffered_Calls_IDatabaseConnection_Query_NoParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = Array.empty

    // Act
    let! _ = task {
        return! (sql, parms)
        ||> ReadWriteDb.queryUnbuffered fakeDbConnection CancellationToken.None
        |> TaskSeq.toArrayAsync
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.QueryUnbuffered(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(Seq.isEmpty),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_QueryUnbuffered_Calls_IDatabaseConnection_Query_WithParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = [| ("@id", box 1) |]

    // Act
    let! result = task {
        return! (sql, parms)
        ||> ReadWriteDb.queryUnbuffered fakeDbConnection CancellationToken.None
        |> TaskSeq.toArrayAsync
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.QueryUnbuffered(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(fun x ->
            Seq.length x = 1 && Seq.head x = KeyValuePair("@id", box 1)),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_QuerySingle_Calls_IDatabaseConnection_QuerySingle_NoParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = Array.empty

    // Act
    let! _ = task {
        return! (sql, parms) ||> ReadWriteDb.querySingle fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.QuerySingle(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(Seq.isEmpty),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_QuerySingle_Calls_IDatabaseConnection_QuerySingle_WithParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = [| ("@id", box 1) |]

    // Act
    let! result = task {
        return! (sql, parms) ||> ReadWriteDb.querySingle fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.QuerySingle(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(fun x ->
            Seq.length x = 1 && Seq.head x = KeyValuePair("@id", box 1)),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_Execute_Calls_IDatabaseConnection_Execute_NoParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = Array.empty

    // Act
    let! _ = task {
        return! (sql, parms) ||> ReadWriteDb.execute fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.Execute(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(Seq.isEmpty),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_Execute_Calls_IDatabaseConnection_Execute_WithParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = [| ("@id", box 1) |]

    // Act
    let! result = task {
        return! (sql, parms) ||> ReadWriteDb.execute fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.Execute(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(fun x ->
            Seq.length x = 1 && Seq.head x = KeyValuePair("@id", box 1)),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_ExecuteScalar_Calls_IDatabaseConnection_ExecuteScalar_NoParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = Array.empty

    // Act
    let! _ = task {
        return! (sql, parms) ||> ReadWriteDb.executeScalar fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.ExecuteScalar(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(Seq.isEmpty),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_ExecuteScalar_Calls_IDatabaseConnection_ExecuteScalar_WithParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = [| ("@id", box 1) |]

    // Act
    let! result = task {
        return! (sql, parms) ||> ReadWriteDb.executeScalar fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.ExecuteScalar(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(fun x ->
            Seq.length x = 1 && Seq.head x = KeyValuePair("@id", box 1)),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_ExecuteReader_Calls_IDatabaseConnection_ExecuteReader_NoParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = Array.empty

    // Act
    let! _ = task {
        return! (sql, parms) ||> ReadWriteDb.executeReader fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.ExecuteReader(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(Seq.isEmpty),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}

[<Test>]
let Db_ExecuteReader_Calls_IDatabaseConnection_ExecuteReader_WithParms () = task {
    // Arrange
    let sql = "SELECT 1 FROM table"
    let parms = [| ("@id", box 1) |]

    // Act
    let! result = task {
        return! (sql, parms) ||> ReadWriteDb.executeReader fakeDbConnection CancellationToken.None
    }

    // Assert
    A.CallTo(fun () -> fakeDbConnection.ExecuteReader(
        "SELECT 1 FROM table",
        A<IEnumerable<KeyValuePair<string, obj>>>.That.Matches(fun x ->
            Seq.length x = 1 && Seq.head x = KeyValuePair("@id", box 1)),
        CancellationToken.None)).MustHaveHappenedOnceExactly ()
    |> ignore
}
