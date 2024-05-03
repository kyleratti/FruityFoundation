module FruityFoundation.Tests.FsBase

open System.Collections.Generic
open FruityFoundation.Base.Structures
open NUnit.Framework
open FsUnit
open FruityFoundation.FsBase

[<Test>]
let ``Array.toReadOnlyCollection casts an array to a read only collection`` () =
    // Arrange
    let input = [|1; 2; 3|]

    // Act
    let result = input |> Array.toReadOnlyCollection

    // Assert
    result |> should be instanceOfType<IReadOnlyCollection<int>>

[<Test>]
let ``Option.toMaybe returns an empty Maybe for None`` () =
    // Arrange
    let input : string option = None

    // Act
    let result = input |> Option.toMaybe

    // Assert
    Assert.That(result, Is.InstanceOf<string Maybe>())
    result |> should be instanceOfType<string Maybe>
    result.HasValue |> should equal false

[<Test>]
let ``Option.toMaybe returns Maybe for Some`` () =
    // Arrange
    let input : string option = Some "banana"

    // Act
    let result = input |> Option.toMaybe

    // Assert
    result |> should be instanceOfType<string Maybe>
    result.HasValue |> should equal true
    result.Value |> should equal "banana"

[<Test>]
let ``ValueOption.toMaybe returns an empty Maybe for None`` () =
    // Arrange
    let input : string ValueOption = ValueNone

    // Act
    let result = input |> ValueOption.toMaybe

    // Assert
    Assert.That(result, Is.InstanceOf<string Maybe>())
    result |> should be instanceOfType<string Maybe>
    result.HasValue |> should equal false

[<Test>]
let ``ValueOption.toMaybe returns Maybe for Some`` () =
    // Arrange
    let input : string ValueOption = ValueSome "banana"

    // Act
    let result = input |> ValueOption.toMaybe

    // Assert
    result |> should be instanceOfType<string Maybe>
    result.HasValue |> should equal true
    result.Value |> should equal "banana"
