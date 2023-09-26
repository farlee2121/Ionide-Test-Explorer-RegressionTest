module XUnitTests

open System
open Xunit


[<Fact>]
let ``Such test`` () =
    Assert.True(true)

[<Fact>]
let ``Contains.separator+characters`` () =
    Assert.True(true)

[<Fact>]
let ``My test`` () =
    Assert.True(true)


[<Fact>]
let ``I Fail`` () =
    Assert.True(false)

module Nested =

    [<Fact>]
    let ``Very Nested`` () =
        Assert.True(false)

    module AnotherLayer =
        [<Fact>]
        let ``Wow`` () =
            Assert.True(true)

type ``Class Based`` () =
    [<Fact>]
    let ``I'm part of a class`` () =
        Assert.True(true)

[<Theory>]
[<InlineData(2,2,4)>]
[<InlineData(2,3,4)>]
let theoryTest (x:int) (y:int) (sum:int) =
    Assert.Equal(sum, x+y)