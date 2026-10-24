module FruityFoundation.FsBase.Array

open System.Collections.Generic

let toReadOnlyCollection (a : 'a array) = a :> 'a IReadOnlyCollection
