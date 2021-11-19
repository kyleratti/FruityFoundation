namespace CommonCore.Db

open System
open System.Data

module Db =
    // Data Readers
    let toNullable (value : 'a option) =
        match value with
        | None -> DBNull.Value :> obj
        | Some x -> x :> obj

    let tryGetBool (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetBoolean |> Some

    let getBool (ord : int32) (record : IDataRecord) =
        match record |> tryGetBool ord with
        | Some x -> x
        | None -> (raise (InvalidOperationException $"Ordinal {ord} is null"))

    let tryGetString (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetString |> Some

    let getString (ord : int32) (record : IDataRecord) =
        match record |> tryGetString ord with
        | Some x -> x
        | None -> (raise (InvalidOperationException $"Ordinal {ord} is null"))

    let tryGetInt32 (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetInt32 |> Some

    let getInt32 (ord : int32) (record : IDataRecord) =
        match record |> tryGetInt32 ord with
        | Some x -> x
        | None -> (raise (InvalidOperationException $"Ordinal {ord} is null"))

    let tryGetInt64 (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetInt64 |> Some

    let getInt64 (ord : int32) (record : IDataRecord) =
        match record |> tryGetInt64 ord with
        | Some x -> x
        | None -> (raise (InvalidOperationException $"Ordinal {ord} is null"))

    let tryGetDateTime (ord : int32) (record : IDataRecord) =
        if ord |> record.IsDBNull then
            None
        else
            ord |> record.GetDateTime |> Some

    let getDateTime (ord : int32) (record : IDataRecord) =
        match record |> tryGetDateTime ord with
        | Some x -> x
        | None -> (raise (InvalidOperationException $"Ordinal {ord} is null"))
