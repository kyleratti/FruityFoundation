namespace CommonCore.Db

open System
open System.Data

module Db =
    // Query Builders
    let createCommand (db : IDbConnection) (sql : string, queryParams : IDbDataParameter list option) =
        let cmd = db.CreateCommand ()
        cmd.CommandText <- sql

        match queryParams with
        | None -> ()
        | Some x ->
            x
            |> Seq.iter (fun parm -> parm |> cmd.Parameters.Add |> ignore)

        cmd

    let private executeNonQuery_impl (cmd : IDbCommand) =
        cmd.ExecuteNonQuery ()

    let private executeReader_impl (cmd : IDbCommand) =
        use reader = cmd.ExecuteReader ()
        seq {
            while reader.Read () do
                yield reader
        }

    let private executeScalar_impl<'a> (cmd : IDbCommand) =
        cmd.ExecuteScalar () :?> 'a

    let executeNonQuery (db : IDbConnection) (sql : string, queryParams : IDbDataParameter list option) =
        (sql, queryParams)
        |> createCommand db
        |> executeNonQuery_impl

    let executeReader (db : IDbConnection) (sql : string, queryParams : IDbDataParameter list option) =
        (sql, queryParams)
        |> createCommand db
        |> executeReader_impl

    let executeScalar (db : IDbConnection) (sql : string, queryParams : IDbDataParameter list option) =
        (sql, queryParams)
        |> createCommand db
        |> executeScalar_impl

    let createTransaction (db : IDbConnection) =
        db.BeginTransaction ()

    let commit (tx : IDbTransaction) =
        tx.Commit ()

    // Data Readers
    let toNullable (value : 'a option) =
        match value with
        | None -> DBNull.Value :> obj
        | Some x -> x :> obj

    let getBool (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetBoolean |> Some

    let getString (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetString |> Some

    let getInt32 (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetInt32 |> Some

    let getInt64 (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetInt64 |> Some

    let getDateTime (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetDateTime |> Some
