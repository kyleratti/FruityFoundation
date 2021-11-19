namespace CommonCore.Db

open System.Data

type IDbConnection =
    abstract ExecuteSQL:
        sql : string
        -> queryParams : IDbDataParameter list option
        -> seq<IDataReader>

    abstract ExecuteNonQuery:
        sql : string
        -> queryParams : IDbDataParameter list option
        -> int

    abstract ExecuteScalar:
        sql : string
        -> queryParams : IDbDataParameter list option
        -> obj